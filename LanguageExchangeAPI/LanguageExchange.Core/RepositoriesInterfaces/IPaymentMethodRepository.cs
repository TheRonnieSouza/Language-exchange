using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IPaymentMethodRepository
    {
        public Task<int> CreatePaymentMethod(PaymentMethod payment);
        public Task<int> UpdatePaymentMethod(Guid id, PaymentMethod payment);
        public Task<int> CancePaymentMethodl(Guid id, Guid UserId);
    }
}
