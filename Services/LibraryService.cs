using LibrarySystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystems.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext _context;

        public LibraryService(LibraryDbContext context)
        {
            _context = context;
        }

   public void AddBook(Book book)
    {
        Console.WriteLine($"Received Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");

    if (book == null) throw new ArgumentNullException(nameof(book));
    // Check that the book properties are correctly populated before saving
    if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author) || string.IsNullOrWhiteSpace(book.ISBN))
    {
        throw new InvalidOperationException("Book details are missing required fields.");
    }
    _context.Books.Add(book);
    _context.SaveChanges(); // Make sure SaveChanges() is called to persist changes to the database
}

        public void AddMember(Member member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void BorrowBooks(List<int> bookIds, int memberId)
        {
            var member = _context.Members.Include(m => m.BorrowedBooks).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null) throw new Exception("Member not found");

            foreach (var id in bookIds)
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id && b.isAvailable);
                if (book != null)
                {
                    book.isAvailable = false;
                    member.BorrowedBooks.Add(book);
                }
            }
            _context.SaveChanges();
        }

        public void ReturnBooks(List<int> bookIds, int memberId)
        {
            var member = _context.Members.Include(m => m.BorrowedBooks).FirstOrDefault(m => m.MemberId == memberId);
            if (member == null) throw new Exception("Member not found");

            foreach (var id in bookIds)
            {
                var book = member.BorrowedBooks.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    book.isAvailable = true;
                    member.BorrowedBooks.Remove(book);
                }
            }
            _context.SaveChanges();
        }

        public List<Book> GetAvailableBooks()
        {
            return _context.Books.Where(b => b.isAvailable).ToList();
        }

        public List<Member> GetMembers()
        {
            return _context.Members.ToList();
        }

        public List<Book> GetOverdueBooks()
        {
            // Complex logic to determine overdue books based on borrowing date
            // Here you might have a property like DueDate in the Book or BorrowedBooks details
            // This is just a placeholder for more complex logic
            return _context.Books.Where(b => !b.isAvailable && b.BorrowDate.HasValue && b.BorrowDate.Value.AddDays(30) < DateTime.Now).ToList();
        }
    }
}
