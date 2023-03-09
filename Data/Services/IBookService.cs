namespace Summaries.Data
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void UpdateBook(Book newBook);
        void DeleteBook(int id);
        void AddBook(Book newBook);
    }
}