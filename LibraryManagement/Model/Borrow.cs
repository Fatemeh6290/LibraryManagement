using System.Runtime.InteropServices.JavaScript;

namespace LibraryManagement.Model;

public class Borrow
{
    public int BorrowId { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}