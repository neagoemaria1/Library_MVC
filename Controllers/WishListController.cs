using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
	[Authorize(Roles = "Admin,Basic")]
	public class WishListController : Controller
	{
		private readonly IUserService _userService;
		private readonly IWishListService _wishListService;
		private readonly IWishList_BookService _wishListBookService;
		private readonly IBookService _bookService;

		public WishListController(
			IUserService userService,
			IWishListService wishListService,
			IWishList_BookService wishListBookService,
			IBookService bookService)
		{
			_userService = userService;
			_wishListService = wishListService;
			_wishListBookService = wishListBookService;
			_bookService = bookService;
		}

		public IActionResult AddMore()
		{
			return RedirectToAction("Index", "Bookshelf");
		}
		public IActionResult Index()
		{
			var user = _userService.GetCurrentUser();
			if (user == null)
			{
				return RedirectToAction("Login", "Account");
			}

			var wishList = _wishListService.GetWishListByUserId(user.Id);
			if (wishList == null)
			{
				wishList = new WishList
				{
					ID_User = user.Id,
					WishList_Book = new List<WishList_Book>()
				};
				_wishListService.AddWishList(wishList);
			}

			var wishListBooks = _wishListBookService.GetAllWishListBookByWishListId(wishList.ID_WishList);

			var model = new WishList
			{
				ID_WishList = wishList.ID_WishList,
				ID_User = wishList.ID_User,
				WishList_Book = wishListBooks.Select(wb => new WishList_Book
				{
					ID_WishList_Book = wb.ID_WishList_Book,  // Updated to match the renamed property
					ISBN = wb.ISBN,
					Book = _bookService.GetBookByISBN(wb.ISBN)
				}).ToList()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult AddBookToWishList(string isbn)
		{
			var user = _userService.GetCurrentUser();
			if (user == null)
			{
				return RedirectToAction("Login", "Account");
			}

			// Check if the book exists in the database
			var book = _bookService.GetBookByISBN(isbn);
			if (book == null)
			{
				TempData["Error"] = "The selected book was not found.";
				return RedirectToAction("Index", "Bookshelf");
			}

			// Check if the user has an existing wishlist
			var wishList = _wishListService.GetWishListByUserId(user.Id);
			if (wishList == null)
			{
				wishList = new WishList
				{
					ID_User = user.Id,
					WishList_Book = new List<WishList_Book>()
				};
				_wishListService.AddWishList(wishList);
			}

			// Check if the book is already in the wishlist
			var existingWishListBook = _wishListBookService.GetWishListBookByWishListIdAndISBN(wishList.ID_WishList, isbn);
			if (existingWishListBook != null)
			{
				TempData["Message"] = "This book is already in your wishlist!";
				return RedirectToAction("Index", "WishList");
			}

			// If not, add the book to the wishlist
			var newWishListBook = new WishList_Book
			{
				ID_WishList = wishList.ID_WishList,
				ISBN = isbn
			};
			_wishListBookService.AddWishListBook(newWishListBook);
			_wishListService.UpdateWishList(wishList);

			TempData["Message"] = "Book added to your wishlist!";
			return RedirectToAction("Index", "WishList");
		}


		[HttpPost]
		public async Task<IActionResult> RemoveBookFromWishList(string isbn)
		{
			var user = _userService.GetCurrentUser();
			if (user == null)
			{
				return RedirectToAction("Login", "Account");
			}

			var wishList = _wishListService.GetWishListByUserId(user.Id);
			if (wishList != null)
			{
				var wishListBook = _wishListBookService.GetWishListBookByWishListIdAndISBN(wishList.ID_WishList, isbn);
				if (wishListBook != null)
				{
					await _wishListBookService.RemoveWishListBookAsync(wishList.ID_WishList, isbn);

				}
			}

			return RedirectToAction("Index", "WishList");
		}
	}
}
