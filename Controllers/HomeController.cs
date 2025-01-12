using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Library.Services;

public class HomeController : Controller
{
    private readonly IReservedBookService _reservedBookService;
    private readonly IReturnRequestService _returnRequestService;
    private readonly IUserService _userService;

    public HomeController(IReservedBookService reservedBookService, UserManager<User> userManager, IReturnRequestService returnRequestService, IUserService userService)
    {
        _reservedBookService = reservedBookService;
        _userService = userService;
        _returnRequestService = returnRequestService;
    }

    public async Task<IActionResult> Index()
    {
        var user = _userService.GetCurrentUser();
        List<ReservedBook> reservedBooks = new List<ReservedBook>();

        if (user != null)
        {
            // Get the list of books reserved for the current user
            reservedBooks = await _reservedBookService.GetReservedBooksByUserAsync(user.Id);
            var returnRequests = await _returnRequestService.GetAllReturnRequestsAsync();

            reservedBooks = reservedBooks
               .Where(rb => !returnRequests.Any(rr => rr.IdUser == user.Id && rr.BookISBN == rb.BookISBN))
               .ToList();
        }

        return View(reservedBooks);
    }

    [HttpPost]
    public async Task<IActionResult> ReturnBook(int id)
    {
        var user = _userService.GetCurrentUser();
        if (user != null)
        {
            // Check if the reserved book exists and belongs to the current user
            var reservedBook = _reservedBookService.GetReservedBookById(id);
            if (reservedBook != null && reservedBook.IdUser == user.Id)
            {
                // If it exists, a return request is created
                var returnRequest = new ReturnRequest
                {
                    RequestDate = DateTime.Now,
                    Description = "Return request for reserved book",
                    IsApproved = false,
                    IdUser = user.Id,
                    BookISBN = reservedBook.BookISBN
                };
                // Add the return request to the database
                await _returnRequestService.AddReturnRequestAsync(returnRequest);
            }
        }

        return RedirectToAction("Index");
    }
}