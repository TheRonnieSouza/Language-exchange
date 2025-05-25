using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IPaymentRepository
    {
        public Task<string> Add(Payment payment);
        public Task<bool> Cancel(string id);
        public Task<Payment> GetPayment(string UserId, string PaymentId);
    }
}
