using eShop.BusinessLogicLayer.Mappers;
using eShop.BusinessLogicLayer.ServiceContracts;
using Microsoft.Extensions.DependencyInjection;
using eShop.BusinessLogicLayer.Validators;
using FluentValidation;
using eShop.ProductsService.BusinessLogicLayer.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Azure.Messaging.ServiceBus;
using eShop.ProductsService.BusinessLogicLayer.ServiceBus;


namespace eShop.ProductsService.BusinessLogicLayer;

public static class DependencyInjection
{
  public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
  {
    //TO DO: Add Business Logic Layer services into the IoC container
    services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

    services.AddValidatorsFromAssemblyContaining
      <ProductAddRequestValidator>();

    services.AddScoped<IProductsService, eShop.BusinessLogicLayer.Services.ProductsService>();

    services.AddTransient<IRabbitMQPublisher, RabbitMQPublisher>();


    //ServiceBus
    services.AddSingleton(_ =>
      new ServiceBusClient(configuration["ServiceBus:eommcerce-servicebus-namespace"]
    ));

    services.AddSingleton<IServiceBusPublisher, ServiceBusPublisher>();

    return services;
  }
}
