using CashbackBeer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashbackBeer.Infra.Data.EntitiesConfiguration
{
    public class PartialSaleConfiguration : IEntityTypeConfiguration<PartialSale>
    {
        public void Configure(EntityTypeBuilder<PartialSale> builder)
        {
            builder.HasKey(p => p.Id);  
        }
    }
}
