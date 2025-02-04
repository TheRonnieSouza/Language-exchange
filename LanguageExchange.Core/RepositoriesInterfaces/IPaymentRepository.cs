using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IPaymentRepository
    {
        public Task<int> Add(Payment payment);
        public Task<bool> Cancel(int id);
        public Task<Payment> GetPayment(int UserId, int PaymentId);
    }
}
