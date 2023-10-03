using ProvaPub.Models;

namespace ProvaPub.Interfaces.Payment
{
    public interface IPayPalPaymentProcessorService
    {
        Task<Order> ProcessPaymentPayPal(string paymentMethod, decimal paymentValue, int customerId);
    }
}
