using Library.Models;
using Library.Repositories.Interfaces;

namespace Library.Repositories
{
	public class WishList_BookRepository : RepositoryBase<WishList_Book>, IWishList_BookRepository
	{
		public WishList_BookRepository(LibraryContext pizzerieContext)
		   : base(pizzerieContext)
		{
		}
	}
}