using ProvaPub.Interfaces;
using ProvaPub.Interfaces.Payment;
using ProvaPub.Services;
using ProvaPub.Services.Payament;

namespace ProvaPub
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProductService, ProductService>();
            serviceProvider.AddScoped<ICustomerService, CustomerService>();
            serviceProvider.AddScoped<IOrderService, OrderService>();
            serviceProvider.AddScoped<ICreditCardPaymentProcessorService, CreditCardPaymentProcessorService>();
            serviceProvider.AddScoped<IPayPalPaymentProcessorService, PayPalPaymentProcessorService>();
            serviceProvider.AddScoped<IPixPaymentProcessorService, PixPaymentProcessorService>();
        }
    }
}
