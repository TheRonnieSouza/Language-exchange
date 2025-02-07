using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public  interface ISubscriptionPlanRepository
    {
        Task<int> CreateSubscriptionPlan(SubscriptionPlan plan);
        Task<int> DeleteSubscriptionPlan(Guid id);
        Task<IList<SubscriptionPlan>> GetAllPlans();
        Task<SubscriptionPlan> GetPlanById(Guid id);
        Task<int> UpdateSubscriptionPlan(Guid id,SubscriptionPlan plan);
    }
}
