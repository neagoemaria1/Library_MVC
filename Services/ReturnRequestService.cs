using Library.Models;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class ReturnRequestService : IReturnRequestService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReturnRequestService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<ReturnRequest>> GetAllReturnRequestsAsync()
        {
            return await _repositoryWrapper.ReturnRequestRepository.FindAll().ToListAsync();
        }

        public async Task AddReturnRequestAsync(ReturnRequest returnRequest)
        {
            _repositoryWrapper.ReturnRequestRepository.Create(returnRequest);
            _repositoryWrapper.Save();
        }


        public async Task DeleteReturnRequestAsync(int requestId)
        {
            var request = await _repositoryWrapper.ReturnRequestRepository.FindByCondition(r => r.IdRequest == requestId).FirstOrDefaultAsync();
            if (request != null)
            {
                _repositoryWrapper.ReturnRequestRepository.Delete(request);
                _repositoryWrapper.Save();
            }
        }
    }
}
