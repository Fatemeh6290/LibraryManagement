using LibraryManagement.Model;

namespace LibraryManagement.Service;

public class BookService
{
    private readonly List<Book> _books = new();
    public void AddBook(string title, string author, bool isAvailable)
    {
      _books.Add(new Book
      {
          BookId = _books.Count + 1,
          Title = title,
          Author = author, 
          IsAvailable = isAvailable
      });
    }

    public List<Book> GetBooks()
    {
        return _books.ToList();
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(x => x.BookId == id);
    }

    public bool DeleteBook(int id)
    {
        Book? book = GetBookById(id);
        if (book is not null)
        {
            _books.Remove(book);
            return true;
        }
        
        return false;
    }

    public List<Book> SearchByTitle(string title)
    {
        return _books.Where(x => x.Title.Contains(title)).ToList();
    }
    
    public List<Book> SearchByAuthor(string author)
    {
        return _books.Where(x => x.Author == author).ToList();
    }
    
    public List<Book> SearchByIsAvailable()
    {
        return _books.Where(x => x.IsAvailable).ToList();
    }
}