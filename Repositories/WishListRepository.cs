using Library.Models;
using Library.Repositories.Interfaces;

namespace Library.Repositories
{
	public class WishListRepository : RepositoryBase<WishList>, IWishListRepository
	{
		public WishListRepository(LibraryContext pizzerieContext)
		   : base(pizzerieContext)
		{
		}
	}
}