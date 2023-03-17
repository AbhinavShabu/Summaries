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
        public async Task<IActionResult> UpdateBook( Book newBook)
        {
            //await _summariesDbContext.Books.AddAsync(book);
            var oldBook = await _summariesDbContext.Books.FirstOrDefaultAsync(x => x.Id == newBook.Id);
            if (oldBook != null)
            {
                oldBook.Title = newBook.Title;
                oldBook.Author = newBook.Author;
                oldBook.Description = newBook.Description;
                oldBook.Rate = newBook.Rate;
                oldBook.DateStart = newBook.DateStart;
                oldBook.DateRead = newBook.DateRead;
            }
            await _summariesDbContext.SaveChangesAsync();
            return Ok();

            //var oldBook = await _summariesDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            //var oldBook = await _summariesDbContext.Books.FindAsync(id);
            //await _summariesDbContext.Books.AddAsync(newBook);

            //if (oldBook == null)
            //{
            //    return NotFound();
            //}


            //oldBook.Title = newBook.Title;
            //oldBook.Author = newBook.Author;
            //oldBook.Description = newBook.Description;
            //oldBook.Rate = newBook.Rate;
            //oldBook.DateStart = newBook.DateStart;
            //oldBook.DateRead = newBook.DateRead;

            //await _summariesDbContext.SaveChangesAsync();

            //return Ok();
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