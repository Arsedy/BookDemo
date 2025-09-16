using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using BookDemo.Data;

namespace BookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BooksController(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books); // Returns a 200 OK response with the list of books
        }
        
        [HttpGet("{id}")]
        public IActionResult GetOneBook(int id)
        {
            var book = _context.Books.Find(id); // Finds a book by its ID from the database
            if (book == null)
            {
                return NotFound(); // Returns a 404 Not Found response if the book doesn't exist
            }
            return Ok(book); // Returns a 200 OK response with the book details
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(); // Returns a 400 Bad Request response if the book is null
            }
            _context.Books.Add(book); // Adds the new book to the database context
            _context.SaveChanges(); // Saves changes to the database
            return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book); // Returns a 201 Created response with the location of the new book
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null || updatedBook.Id != id)
            {
                return BadRequest(); // Returns a 400 Bad Request response if the book is null or IDs don't match
            }
            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound(); // Returns a 404 Not Found response if the book doesn't exist
            }
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.YearPublished = updatedBook.YearPublished;
            _context.Books.Update(existingBook); // Updates the existing book in the database context
            _context.SaveChanges(); // Saves changes to the database
            return Ok(existingBook);// Returns a 200 OK response with the updated book details
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound(); // Returns a 404 Not Found response if the book doesn't exist
            }
            _context.Books.Remove(book); // Removes the book from the database context
            _context.SaveChanges(); // Saves changes to the database
            return Ok(GetBooks()); // Returns a 200 OK response with the list of remaining books
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            var books = _context.Books.ToList();
            if (books.Count == 0)
            {
                return NotFound(); // Returns a 404 Not Found response if there are no books to delete
            }
            _context.Books.RemoveRange(books); // Removes all books from the database context
            _context.SaveChanges(); // Saves changes to the database
            return Ok("All books have been deleted."); // Returns a 200 OK response confirming deletion
        }
        
    }
}
