using ProvaPub.Models;

namespace ProvaPub.Interfaces.Payment
{
    public interface IPixPaymentProcessorService
    {
        Task<Order> ProcessPaymentPix(string paymentMethod, decimal paymentValue, int customerId);
    }
}
