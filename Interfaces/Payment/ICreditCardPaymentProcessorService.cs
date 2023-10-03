using ProvaPub.Models;

namespace ProvaPub.Interfaces.Payment
{
    public interface ICreditCardPaymentProcessorService
    {
        Task<Order> ProcessPaymentCreditCard(string paymentMethod, decimal paymentValue, int customerId);
    }
}
