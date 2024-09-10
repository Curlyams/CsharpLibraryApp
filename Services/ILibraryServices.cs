using LibrarySystems.Models;
using System.Collections.Generic;

namespace LibrarySystems.Services
{
    public interface ILibraryService
    {
        void AddBook(Book book);
        void AddMember(Member member);
        void BorrowBooks(List<int> bookIds, int memberId);
        void ReturnBooks(List<int> bookIds, int memberId);
        List<Book> GetAvailableBooks();
        List<Member> GetMembers();
        List<Book> GetOverdueBooks();
    }
}
