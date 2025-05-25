using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public PaymentRepository(LanguageExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(Payment payment)
        {
            _context.PaymentTransactions.Add(payment);
            await _context.SaveChangesAsync();
            return payment.Id.ToString();
        }

        public async Task<bool> Cancel(string id)
        {
            var payment = await _context.PaymentTransactions.FindAsync(id);
            payment.MarkFailed();
            await _context.SaveChangesAsync();
            return payment.IsSuccessful();
        }

        public async Task<Payment> GetPayment(string UserId, string PaymentId)
        {
            var result = await _context.PaymentTransactions.FirstOrDefaultAsync(x => x.UserId.ToString() == UserId && x.Id.ToString() == PaymentId);

            if(result == null)
            {
                throw new Exception("Payment not found");
            }
            return result;
        }
    }
}
