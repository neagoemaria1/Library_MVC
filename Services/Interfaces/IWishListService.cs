using Library.Models;
using System.Collections.Generic;

namespace Library.Services.Interfaces
{
	public interface IWishListService
	{

		WishList GetWishListByUserId(string userId);
		void AddWishList(WishList wishList);
		void UpdateWishList(WishList wishList);
		void AddBookToWishList(int wishListId, string isbn);
		void RemoveBookFromWishList(int wishListId, string isbn);
		List<Book> GetBooksInWishList(string userId);
	}
}
