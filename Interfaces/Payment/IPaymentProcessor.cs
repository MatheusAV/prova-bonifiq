using ProvaPub.Models;

namespace ProvaPub.Interfaces.Payment
{
    public interface IPaymentProcessor
    {
        Task<Order> ProcessPayment(string paymentMethod, decimal paymentValue, int customerId);
    }
}
