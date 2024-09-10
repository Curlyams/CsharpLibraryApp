using LibrarySystems.Models;
using LibrarySystems.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibrarySystems.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public IActionResult ListAvailableBooks()
        {
            var availableBooks = _libraryService.GetAvailableBooks();
            return View(availableBooks);
        }

        public IActionResult ListAvailableMembers()
        {
            var members = _libraryService.GetMembers();
            return View(members);
        }

        [HttpPost]
        public IActionResult BorrowBooks(List<int> bookIds, int memberId)
        {
            _libraryService.BorrowBooks(bookIds, memberId);
            return RedirectToAction("ListAvailableBooks");
        }

        [HttpPost]
        public IActionResult ReturnBooks(List<int> bookIds, int memberId)
        {
            _libraryService.ReturnBooks(bookIds, memberId);
            return RedirectToAction("ListAvailableBooks");
        }

        // GET: Library/AddBook
        [HttpGet]
        public IActionResult AddBook()
        {
            return View(); // Render the form for adding a new book
        }

     // POST: Library/AddBook
[HttpPost("/Library/AddBook"/*, new { area = "" } */)]
public IActionResult AddBook(Book book)
{
    // Check the received values - this can help diagnose binding issues
    Console.WriteLine($"Received Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");

    if (ModelState.IsValid)
    {
        _libraryService.AddBook(book);
        return RedirectToAction("ListAvailableBooks");
    }

    // Log any model state errors
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine(error.ErrorMessage);
    }

    return View(book); // Return view with the validation errors
}


        // GET: Library/AddMember
        [HttpGet]
        public IActionResult AddMember()
        {
            return View(new Member()); // Render the form for adding a new member
        }

        // POST: Library/AddMember
        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddMember(member);
                // Redirect to ListAvailableMembers after adding a member
                return RedirectToAction("ListAvailableMembers");
            }
            return View(member); // Return view with the validation errors
        }

        public IActionResult ListOverdueBooks()
        {
            var overdueBooks = _libraryService.GetOverdueBooks();
            return View(overdueBooks);
        }
    }
}
