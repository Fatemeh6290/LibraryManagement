using LibraryManagement.Model;

namespace LibraryManagement.Service;

public class BorrowService
{
    private readonly List<Borrow> _borrow = new();
    private readonly BookService _bookService;
    private readonly MemberService _memberService;

    public BorrowService(BookService bookService, MemberService memberService)
    {
        _bookService = bookService;
        _memberService = memberService;
    }

    public bool AddBorrow(int bookId, int memberId, DateTime borrowDate, DateTime returnDate)
    {
        var book = _bookService.GetBookById(bookId);
        var member = _memberService.GetMemberById(memberId);
        
        if (book is null || member is null || !book.IsAvailable)
            return false;
        
        _borrow.Add(new Borrow
        {
            BorrowId = _borrow.Count + 1,
            BookId = bookId,
            MemberId = memberId,
            BorrowDate = DateTime.Now,
            ReturnDate = null
        });
        
        book.IsAvailable = false;
        return true;
    }

    public bool ReturnBorrow(int bookId)
    {
        var book = _bookService.GetBookById(bookId);
        
        if (book is null)
            return false;
        
        var borrow = _borrow.FirstOrDefault(x => x.BookId == bookId && x.ReturnDate == null);

        if (borrow is null)
            return false;
        
        borrow.ReturnDate = DateTime.Now;
        book.IsAvailable = true;
        
        return true;
    }
}