using CashbackBeer.Application.Interfaces;
using CashbackBeer.Application.Services;
using CashbackBeer.Domain.Interfaces;
using CashbackBeer.Infra.Data.Context;
using CashbackBeer.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashbackBeer.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<IFinalSaleRepository, FinalSaleRepository>();
            services.AddScoped<IFinalSaleService, FinalSaleService>();
            services.AddScoped<IBeerService, BeerService>();

            return services;
        }
    }
}
