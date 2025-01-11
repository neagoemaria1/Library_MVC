using Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
	public interface IWishList_BookService
	{
		IEnumerable<WishList_Book> GetAllWishListBookByWishListId(int wishListId);

		WishList_Book GetWishListBookByWishListIdAndISBN(int wishListId, string isbn);

		void AddWishListBook(WishList_Book wishListBook);

		void UpdateWishListBook(WishList_Book wishListBook);

		Task RemoveWishListBookAsync(int wishListId, string isbn);
	}
}
