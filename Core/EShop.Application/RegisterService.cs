using Microsoft.Extensions.DependencyInjection;
using EShop.Application.Features.Product.Queries.GetAllProducts;

namespace EShop.Application;

public static class RegisterService
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAllProductsHandler).Assembly));
    }
}