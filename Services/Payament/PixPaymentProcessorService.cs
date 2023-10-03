using ProvaPub.Interfaces;
using ProvaPub.Interfaces.Payment;
using ProvaPub.Models;

namespace ProvaPub.Services.Payament
{
    public class PixPaymentProcessorService : IPixPaymentProcessorService
    {
        public Task<Order> ProcessPaymentPix(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentMethod == "pix")
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