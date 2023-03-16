using Microsoft.EntityFrameworkCore;
//using Summaries.Models;

namespace Summaries.Data
{
    public class SummariesDbContext : DbContext
    {
        public SummariesDbContext(DbContextOptions<SummariesDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
