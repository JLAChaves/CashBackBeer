using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.Application.Interfaces
{
    public interface IFinalSaleService
    {
        Task Add(FinalSale finalSale);
        Task<FinalSale> GetById(int id);
        GeneralPagination<FinalSale> GetAll(PaginationParams pagination);
        GeneralPagination<FinalSale> GetFinalSaleByDate(PaginationParams pagination, DateTime? minDate, DateTime? maxDate);
    }
}
