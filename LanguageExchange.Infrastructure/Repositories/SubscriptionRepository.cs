using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public SubscriptionRepository(LanguageExchangeDbContext context) 
        {
            _context = context;
        }      

        public async Task<int> CancelSubscription(Guid userId)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId 
                                && s.Status == StatusSubscriptionEnum.Active);
            subscription.CancelSubscription();
            _context.Update(subscription);
            return await _context.SaveChangesAsync();
        }

        public async Task<Guid> CreateSubscription(Guid userId, Subscription subscription)
        {
             await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return subscription.Id;
        }

        public async Task<Subscription> GetCurrentSubscription(Guid userId)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s =>s.UserId == userId
                        && s.Status == StatusSubscriptionEnum.Active);

        }

        public async Task<IList<Subscription>> GetHistorySubscription(Guid userId)
        {
            return await _context.Subscriptions.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<int> UpdateSubscription(Guid userId, Subscription newSubscription)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId
                                && s.Status == StatusSubscriptionEnum.Active);

            subscription.Update(newSubscription.SubscriptionPlanId, newSubscription.StartDate, newSubscription.EndDate, newSubscription.IsRecurring, newSubscription.PaymentProviderSubscriptionId, newSubscription.Status);
            _context.Update(subscription);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UserHasSubscription(Guid userId)
        {
            var result = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId
                                                    && s.Status != StatusSubscriptionEnum.Active);
            if(result == null)
                return false;
            return true;
        }
        public async Task ActivateSubscription(Guid userId)
        {
            var result = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId
                                                    && s.Status != StatusSubscriptionEnum.Active);
            result.ActivateSubscription();
        }
    }
}
