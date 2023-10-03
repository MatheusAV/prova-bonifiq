using ProvaPub.Interfaces.Payment;
using ProvaPub.Models;

namespace ProvaPub.Services.Payament
{
    public class PayPalPaymentProcessorService : IPayPalPaymentProcessorService
    {
        public Task<Order> ProcessPaymentPayPal(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentMethod == "paypal")
            {
                var order = new Order
                {
                    Value = paymentValue,
                    CustomerId = customerId,
                    OrderDate = DateTime.UtcNow
                };

                return Task.FromResult(order);
            }

            throw new InvalidOperationException("Método de pagamento não suportado.");
        }
    }
}
