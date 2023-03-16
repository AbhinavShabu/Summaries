using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summaries.Data;

namespace Summaries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: Controller
    {
        //private IBookService _service;
        //public BooksController(BookService service)
        //{
        //    _service = service;
        //}

        private SummariesDbContext _summariesDbContext;

        public BooksController(SummariesDbContext summariesDbContext) 
        {
            _summariesDbContext = summariesDbContext;
        }

        // Create or add new books
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
                    await _summariesDbContext.Books.AddAsync(book);
                    await _summariesDbContext.SaveChangesAsync();
                    return Ok(book);
        }

        // Read all books
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetBooks()
        {
            var allBooks = await _summariesDbContext.Books.ToListAsync();
            return Ok(allBooks);
        }

        // Update an existing book
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id,[FromBody]Book book)
        {
            var update = await _summariesDbContext.Books.FindAsync(id);
            //await _summariesDbContext.Books.AddAsync(book);
            //await _summariesDbContext.SaveChangesAsync();

            return Ok(update);
        }

        // Delete a Book
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _summariesDbContext.Books.FirstAsync(x => x.Id == id);
            _summariesDbContext.Books.Remove(book);
            await _summariesDbContext.SaveChangesAsync();
            return Ok();
        }

        // Get a single book by id
        [HttpGet("SingleBook/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _summariesDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(book);
        }

    }
}