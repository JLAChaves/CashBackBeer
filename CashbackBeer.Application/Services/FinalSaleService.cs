using CashbackBeer.Application.Interfaces;
using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Interfaces;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.Application.Services
{
    public class FinalSaleService : IFinalSaleService
    {
        private readonly IFinalSaleRepository _finalSaleRepository;

        public FinalSaleService(IFinalSaleRepository finalSaleRepository)
        {
            _finalSaleRepository = finalSaleRepository;
        }
        public async Task Add(FinalSale finalSale)
        {
            await _finalSaleRepository.CreateFinalSaleAsync(finalSale);
        }

        public async Task<FinalSale> GetById(int id)
        {
            return await _finalSaleRepository.GetFinalSaleByIdAsync(id);
        }

        public GeneralPagination<FinalSale> GetAll(PaginationParams pagination)
        {
            return _finalSaleRepository.GetAll(pagination);
        }

        public GeneralPagination<FinalSale> GetFinalSaleByDate(PaginationParams pagination, DateTime? minDate, DateTime? maxDate)
        {
            return _finalSaleRepository.GetFinalSaleByDate(pagination, minDate, maxDate);
        }
    }
}
