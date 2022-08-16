using CashbackBeer.Application.Interfaces;
using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Interfaces;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.Application.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<Beer> GetBeerById(int id)
        {
            return await _beerRepository.GetBeerByIdAsync(id);
        }

        public GeneralPagination<Beer> GetBeersByName(PaginationParams pagination, string? name)
        {
            return _beerRepository.GetBeersByName(pagination, name);
        }      
    }
}
