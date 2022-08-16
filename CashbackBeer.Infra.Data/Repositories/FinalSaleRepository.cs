using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Interfaces;
using CashbackBeer.Domain.Pagination;
using CashbackBeer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CashbackBeer.Infra.Data.Repositories
{
    public class FinalSaleRepository : IFinalSaleRepository
    {
        ApplicationDbContext _finalSaleContext;

        public FinalSaleRepository(ApplicationDbContext finalSaleContext)
        {
            _finalSaleContext = finalSaleContext;
        }

        public async Task<FinalSale> CreateFinalSaleAsync(FinalSale finalSale)
        {
            UpdatePartialSale(finalSale);
            UpdateFinalSale(finalSale);
            _finalSaleContext.FinalSales.Add(finalSale);
            await _finalSaleContext.SaveChangesAsync();
            return finalSale;
        }

        public async Task<FinalSale> GetFinalSaleByIdAsync(int id)
        {
            return await _finalSaleContext.FinalSales.Include(h => h.PartialSales)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public GeneralPagination<FinalSale> GetAll(PaginationParams pagination)
        {
            IQueryable<FinalSale> sales = _finalSaleContext.FinalSales.AsNoTracking().Include(h=> h.PartialSales).OrderBy(p => p.Id);

            return GetPaginationFinalSale(pagination, sales);
        }

        public GeneralPagination<FinalSale> GetFinalSaleByDate(PaginationParams pagination, DateTime? minDate, DateTime? maxDate)
        {               

            IQueryable<FinalSale> sales = _finalSaleContext.FinalSales.Include(h => h.PartialSales);
            if (minDate.HasValue)
            {
                sales = sales.Where(p => p.DateSale >= minDate).OrderBy(p => p.DateSale);
            }
            if (maxDate.HasValue)
            {
                DateTime date = (DateTime) maxDate;
                date = date.AddHours(23).AddMinutes(59).AddSeconds(59);
                sales = sales.Where(p => p.DateSale <= date);
            }

            return GetPaginationFinalSale(pagination, sales);
        }

        public GeneralPagination<FinalSale> GetPaginationFinalSale(PaginationParams pagination, IQueryable<FinalSale> sales)
        {
            int pageAmount = (int)Math.Ceiling((sales.Count()) / ((double)pagination.Limit));
            List<FinalSale> getSales = sales
                .Skip(pagination.GetOffset())
                .Take(pagination.Limit)
                .ToList();

            return new GeneralPagination<FinalSale>(pageAmount: pageAmount, items: getSales.ToArray());
        }

        private FinalSale UpdatePartialSale(FinalSale finalSale)
        {
            foreach (var item in finalSale.PartialSales)
            {
                var beer = _finalSaleContext.Beers.FirstOrDefault(p => p.Id == item.BeerId);
                item.PartialValue(item.Amount, beer.Value);
                item.CashbackSale(beer);
                item.CashBackValue();
            }
            return finalSale;
        }

        private FinalSale UpdateFinalSale(FinalSale finalSale)
        {
            finalSale.TotalValue();
            finalSale.SetTotalCashback();
            finalSale.SetTotalCashbackValue();
            return finalSale;
        }
    }
}
