using Microsoft.AspNetCore.Mvc;
using Summaries.Data;

namespace Summaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: Controller
    {
        private IBookService _service;
        public BooksController(BookService service)
        {
            _service = service;
        }

        // Create or add new books
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                if(book.Author != null && book.Title != null && book.Description != null)
                {
                    _service.AddBook(book);
                    return Ok();
                }
                return BadRequest("Book was not added");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Read all books
        [HttpGet("[Action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        // Update an existing book
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Book book)
        {
            _service.UpdateBook(book);
            return Ok(book);
        }

        // Delete a Book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }

        // Get a single book by id
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
    }
}