using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookDemo.Models;
using BookDemo.Data;

namespace BookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(ApplicationContext.Books);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetBookById([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            if (book == null) 
            {
                return NotFound();// 404
            }
            else return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest(); // 400
                }
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);// 500
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id , [FromBody] Book book)
        {
            try
            {
                if (book == null || !id.Equals(book.Id))
                {
                    return BadRequest(); // 400
                }
                var existingBook = ApplicationContext
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (existingBook == null)
                {
                    return NotFound(); // 404
                }

                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.YearPublished = book.YearPublished;

                return Ok(existingBook);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);// 500
            }
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var existingBook = ApplicationContext
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (existingBook == null)
                {
                    return NotFound(); // 404
                }

                ApplicationContext.Books.Remove(existingBook);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);// 500
            }
        }
    }
}
