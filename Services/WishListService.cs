using Library.Models;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class WishListService : IWishListService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public WishListService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        /*public WishList GetWishListByUserId(string userId)
               {
                   return _repositoryWrapper.WishListRepository
                       .FindByCondition(wl => wl.ID_User == userId)
                       .Include(wl => wl.WishList_Book)
                       .ThenInclude(wb => wb.Book)
                       .FirstOrDefault();
               }*/

        public WishList GetWishListByUserId(string userId)
        {
            return _repositoryWrapper.WishListRepository
                .FindByCondition(wl => wl.ID_User == userId).FirstOrDefault();
        }
        public void AddWishList(WishList wishList)
        {
            _repositoryWrapper.WishListRepository.Create(wishList);
            _repositoryWrapper.Save();
        }

        public void UpdateWishList(WishList wishList)
        {
            _repositoryWrapper.WishListRepository.Update(wishList);
            _repositoryWrapper.Save();
        }

        public void AddBookToWishList(int wishListId, string isbn)
        {
            var wishListBook = new WishList_Book
            {
                ID_WishList = wishListId,
                ISBN = isbn
            };

            _repositoryWrapper.WishList_BookRepository.Create(wishListBook);
            _repositoryWrapper.Save();
        }

        public void RemoveBookFromWishList(int wishListId, string isbn)
        {
            var wishListBook = _repositoryWrapper.WishList_BookRepository
                .FindByCondition(wb => wb.ID_WishList == wishListId && wb.ISBN == isbn)
                .FirstOrDefault();

            if (wishListBook != null)
            {
                _repositoryWrapper.WishList_BookRepository.Delete(wishListBook);
                _repositoryWrapper.Save();
            }
        }

        public List<Book> GetBooksInWishList(string userId)
        {
            var wishList = GetWishListByUserId(userId);
            if (wishList == null) return new List<Book>();

            return wishList.WishList_Book?
                .Select(wb => wb.Book)
                .ToList() ?? new List<Book>();
        }
    }
}
