using CashbackBeer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashbackBeer.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<PartialSale> PartialSales { get; set; }
        public DbSet<FinalSale> FinalSales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
