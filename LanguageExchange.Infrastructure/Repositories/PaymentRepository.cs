using LanguageExchange.Core.Entities;
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
        public async Task<int> Add(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment.Id;
        }

        public async Task<bool> Cancel(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            payment.Cancel();
            await _context.SaveChangesAsync();
            return payment.IsCanceled;
        }

        public async Task<Payment> GetPayment(int UserId, int PaymentId)
        {
            var result = await _context.Payments.FirstOrDefaultAsync(x => x.UserId == UserId && x.Id == PaymentId);

            if(result == null)
            {
                throw new Exception("Payment not found");
            }
            return result;
        }
    }
}
