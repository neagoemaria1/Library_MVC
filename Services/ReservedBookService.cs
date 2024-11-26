using Library.Models;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class ReservedBookService : IReservedBookService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReservedBookService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<ReservedBook> GetAllReservedBooks()
        {
            return _repositoryWrapper.ReservedBookRepository.FindAll().ToList();
        }

        public void AddReservedBook(ReservedBook reservedBook)
        {
            _repositoryWrapper.ReservedBookRepository.Create(reservedBook);
            _repositoryWrapper.Save();
        }

        public void UpdateReservedBook(ReservedBook reservedBook)
        {
            _repositoryWrapper.ReservedBookRepository.Update(reservedBook);
            _repositoryWrapper.Save();
        }

        public void DeleteReservedBook(int id)
        {
            var reservedBook = _repositoryWrapper.ReservedBookRepository.FindByCondition(rb => rb.IdReservedBook == id).FirstOrDefault();
            if (reservedBook != null)
            {
                _repositoryWrapper.ReservedBookRepository.Delete(reservedBook);
                _repositoryWrapper.Save();
            }
            else
            {
                throw new ArgumentException($"ReservedBook with ID {id} not found.");
            }
        }
    }
}