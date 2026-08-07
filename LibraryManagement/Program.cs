using LibraryManagement.Service;
using LibraryManagement.UI;

var bookService = new BookService();
var memberService = new MemberService();

var borrowService = new BorrowService(
    bookService,
    memberService);
    
var menu = new LibraryMenu(
    bookService,
    memberService,
    borrowService);
    
menu.ShowMenu();