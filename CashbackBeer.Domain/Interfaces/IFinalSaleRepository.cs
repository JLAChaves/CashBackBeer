using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashbackBeer.Domain.Interfaces
{
    public interface IFinalSaleRepository
    {
        GeneralPagination<FinalSale> GetAll(PaginationParams pagination);
        Task<FinalSale> GetFinalSaleByIdAsync(int id);
        GeneralPagination<FinalSale> GetFinalSaleByDate(PaginationParams pagination, DateTime? minDate, DateTime? maxDate);
        Task<FinalSale> CreateFinalSaleAsync(FinalSale finalSale);       
    }
}
