using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class SubscriptionPlanRepository : ISubscriptionPlanRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public SubscriptionPlanRepository(LanguageExchangeDbContext context) 
        {
            _context = context;
        }

        public async Task<Guid> CreateSubscriptionPlan(SubscriptionPlan plan)
        {
            await _context.SubscriptionPlans.AddAsync(plan);
            await _context.SaveChangesAsync();
            return plan.Id;
        }

        public async Task<int> DeleteSubscriptionPlan(Guid id)
        {
            var plan = await _context.SubscriptionPlans.FirstOrDefaultAsync(plan => plan.Id == id && plan.IsActive);
            plan.Desactivate();
                _context.Update(plan);
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<SubscriptionPlan>> GetAllPlans()
        {
            return await _context.SubscriptionPlans.Where(plan => plan.IsActive).ToListAsync();
        }

        public async Task<SubscriptionPlan> GetPlanById(Guid id)
        {
            return await _context.SubscriptionPlans.FirstOrDefaultAsync(plan => plan.Id == id && plan.IsActive);
        }

        public async Task<int> UpdateSubscriptionPlan(Guid id, SubscriptionPlan newPlan)
        {
            var plan = await _context.SubscriptionPlans.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            
            if (plan == null) 
                return 0;

            plan.Update(newPlan.Name, newPlan.Price, newPlan.Currency, newPlan.Duration, newPlan.Features);
            _context.Update(plan);
            return await _context.SaveChangesAsync();
        }
    }
}
