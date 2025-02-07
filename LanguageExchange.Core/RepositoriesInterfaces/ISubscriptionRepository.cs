using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface ISubscriptionRepository
    {
        Task<int> CancelSubscription(Guid userId);
        Task<int> CreateSubscription(Guid userId, Subscription subscription);
        Task<int> UpdateSubscription(Guid userId, Subscription subscription);
        Task<Subscription> GetCurrentSubscription(Guid userId);
        Task<IList<Subscription>> GetHistorySubscription(Guid userId);
    }
}
