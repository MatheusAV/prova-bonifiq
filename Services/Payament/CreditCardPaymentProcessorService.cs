using ProvaPub.Interfaces.Payment;
using ProvaPub.Models;

namespace ProvaPub.Services.Payament
{
    public class CreditCardPaymentProcessorService : ICreditCardPaymentProcessorService
    {
        public Task<Order> ProcessPaymentCreditCard(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentMethod == "creditcard")
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
