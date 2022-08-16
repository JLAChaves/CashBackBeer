using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.Application.Interfaces
{
    public interface IBeerService
    {
        GeneralPagination<Beer> GetBeersByName(PaginationParams pagination, string? name);
        Task<Beer> GetBeerById(int id);
    }
}
