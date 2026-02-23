using eShop.ProductsService.BusinessLogicLayer.RabbitMQ;
using eShop.BusinessLogicLayer.Mappers;
using eShop.BusinessLogicLayer.ServiceContracts;
using eShop.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.ProductsService.BusinessLogicLayer
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
      //TO DO: Add Data Access Layer services into the IoC container

      services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
      services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>(); 
      services.AddScoped<IProductsService, eShop.BusinessLogicLayer.Services.ProductsService>();
      services.AddTransient<IRabbitMQPublisher, RabbitMQPublisher>();
      return services;
    }
  }
}
