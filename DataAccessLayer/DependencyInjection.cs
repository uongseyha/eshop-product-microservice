using eShop.DataAccessLayer.Repositories;
using eShop.DataAccessLayer.Context;
using eShop.DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.ProductsService.DataAccessLayer
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
      //TO DO: Add Data Access Layer services into the IoC container

      services.AddDbContext<ApplicationDbContext>(options => {
        options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
      });

      services.AddScoped<IProductsRepository, ProductsRepository>();
      return services;
    }
  }
}
