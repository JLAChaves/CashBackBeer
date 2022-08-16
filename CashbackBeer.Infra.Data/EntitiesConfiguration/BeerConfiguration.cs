using CashbackBeer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashbackBeer.Infra.Data.EntitiesConfiguration
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Value).IsRequired();

            builder.HasData(
                new Beer(01, "SKOL", 3, 0.25, 0.07, 0.06, 0.02, 0.10, 0.15, 0.20),
                new Beer(02, "BRAHMA", 4, 0.30, 0.05, 0.10, 0.15, 0.20, 0.25, 0.30),
                new Beer(03, "STELLA", 5, 0.35, 0.03, 0.05, 0.08, 0.13, 0.18, 0.25),
                new Beer(04, "BOHEMIA", 4, 0.4, 0.10, 0.15, 0.15, 0.15, 0.20, 0.40)
                );
        }
    }
}
