using Library.Models;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class WishList_BookService : IWishList_BookService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public WishList_BookService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<WishList_Book> GetAllWishListBookByWishListId(int wishListId)
        {
            return _repositoryWrapper.WishList_BookRepository
                .FindByCondition(wp => wp.ID_WishList == wishListId)
                .Include(wp => wp.Book)
                .ToList();
        }

        public WishList_Book GetWishListBookByWishListIdAndISBN(int wishListId, string isbn)
        {
            return _repositoryWrapper.WishList_BookRepository
                .FindByCondition(wp => wp.ID_WishList == wishListId && wp.ISBN == isbn)
                .Include(wp => wp.Book)
                .FirstOrDefault();
        }

        public void AddWishListBook(WishList_Book wishListBook)
        {
            _repositoryWrapper.WishList_BookRepository.Create(wishListBook);
            _repositoryWrapper.Save();
        }

        public void UpdateWishListBook(WishList_Book wishListBook)
        {
            _repositoryWrapper.WishList_BookRepository.Update(wishListBook);
            _repositoryWrapper.Save();
        }

        public async Task RemoveWishListBookAsync(int wishListId, string isbn)
        {
            var wishListBook = _repositoryWrapper.WishList_BookRepository
                .FindByCondition(wp => wp.ID_WishList == wishListId && wp.ISBN == isbn)
                .FirstOrDefault();

            if (wishListBook != null)
            {
                _repositoryWrapper.WishList_BookRepository.Delete(wishListBook);
                await _repositoryWrapper.SaveAsync();
            }
        }
    }
}
