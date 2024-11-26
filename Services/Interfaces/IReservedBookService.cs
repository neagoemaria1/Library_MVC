using Library.Models;
using System.Collections.Generic;

namespace Library.Services.Interfaces
{
    public interface IReservedBookService
    {
        List<ReservedBook> GetAllReservedBooks();
        void AddReservedBook(ReservedBook reservedBook);
        void UpdateReservedBook(ReservedBook reservedBook);
        void DeleteReservedBook(int id);
    }
}