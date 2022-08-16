using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.Domain.Interfaces
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetBeersAsync();
        GeneralPagination<Beer> GetBeersByName(PaginationParams pagination, string? name);
        Task<Beer> GetBeerByIdAsync(int id);
        Task<Beer> CreateBeerAsync(Beer beer);
        Task<Beer> UpdateBeerAsync(Beer beer);
        Task<Beer> RemoveBeerAsync(Beer beer);
    }
}
