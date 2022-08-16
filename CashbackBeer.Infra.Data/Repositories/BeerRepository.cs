using CashbackBeer.Domain.Entities;
using CashbackBeer.Domain.Interfaces;
using CashbackBeer.Domain.Pagination;
using CashbackBeer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CashbackBeer.Infra.Data.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        ApplicationDbContext _beerContext;

        public BeerRepository(ApplicationDbContext beerContext)
        {
            _beerContext = beerContext;
        }

        public async Task<IEnumerable<Beer>> GetBeersAsync()
        {
            return await _beerContext.Beers.ToListAsync();
        }
       
        public GeneralPagination<Beer> GetBeersByName(PaginationParams pagination, string? name)
        {
            IQueryable<Beer> beers;
            if (name != null)
            {
                 beers = _beerContext.Beers.AsNoTracking().Where(p => p.Name.Contains(name)).OrderBy(p => p.Name);
            }
            else
            {
                beers = _beerContext.Beers.AsNoTracking().OrderBy(p => p.Id);
            }
            

            int pageAmount = (int)Math.Ceiling((beers.Count()) / ((double)pagination.Limit));

            List<Beer> getBeers = beers
                .Skip(pagination.GetOffset())
                .Take(pagination.Limit)
                .ToList();

            return new GeneralPagination<Beer>(pageAmount: pageAmount, items: getBeers.ToArray());
        }

        public async Task<Beer> GetBeerByIdAsync(int id)
        {
            return await _beerContext.Beers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Beer> CreateBeerAsync(Beer beer)
        {
            _beerContext.Add(beer);
            await _beerContext.SaveChangesAsync();
            return beer;
        }
           
        public async Task<Beer> RemoveBeerAsync(Beer beer)
        {
            _beerContext.Remove(beer);
            await _beerContext.SaveChangesAsync();
            return beer;
        }

        public async Task<Beer> UpdateBeerAsync(Beer beer)
        {
            _beerContext.Update(beer);
            await _beerContext.SaveChangesAsync();
            return beer;
        }

        
    }
}
