using ProvaPub.Interfaces;
using ProvaPub.Interfaces.Payment;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPixPaymentProcessorService _pix;
        private readonly IPayPalPaymentProcessorService _payPal;
        private readonly ICreditCardPaymentProcessorService _creditCard;

        public OrderService(IPixPaymentProcessorService pix, IPayPalPaymentProcessorService payPal, ICreditCardPaymentProcessorService creditCard)
        {
            _pix = pix;
            _payPal = payPal;
            _creditCard = creditCard;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            switch (paymentMethod.ToLower())
            {
                case "paypal":
                    return await _payPal.ProcessPaymentPayPal(paymentMethod, paymentValue, customerId);
                case "creditcard":
                    return await _creditCard.ProcessPaymentCreditCard(paymentMethod, paymentValue, customerId);
                case "pix":
                    return await _pix.ProcessPaymentPix(paymentMethod, paymentValue, customerId);

                default:
                    return await Task.FromResult<Order>(null); // Método de pagamento não suportado
            }
        }
    }
}
