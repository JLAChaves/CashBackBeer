using CashbackBeer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashbackBeer.Infra.Data.EntitiesConfiguration
{
    public class FinalSaleConfiguration : IEntityTypeConfiguration<FinalSale>
    {
        public void Configure(EntityTypeBuilder<FinalSale> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
