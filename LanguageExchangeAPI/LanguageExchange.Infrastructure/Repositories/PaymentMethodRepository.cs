using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public PaymentMethodRepository(LanguageExchangeDbContext context)
        {
            _context = context;
        }

        public Task<int> CancePaymentMethodl(Guid id, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreatePaymentMethod(PaymentMethod payment)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePaymentMethod(Guid id, PaymentMethod payment)
        {
            throw new NotImplementedException();
        }
    }
}
