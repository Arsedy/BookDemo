using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(Data.ApplicationContext.Books);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetBookById([FromRoute(Name = "Id")] int id)
        {
            var book = Data.ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            if (book == null) 
            {
                return NotFound();// 404
            }
            else return Ok(book);
        }
        
    }
}
