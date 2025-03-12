using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface ISubscriptionRepository
    {
        Task<int> CancelSubscription(Guid userId);
        Task<Guid> CreateSubscription(Guid userId, Subscription subscription);
        Task<int> UpdateSubscription(Guid userId, Subscription subscription);
        Task<Subscription> GetCurrentSubscription(Guid userId);
        Task<IList<Subscription>> GetHistorySubscription(Guid userId);
        Task<bool> UserHasSubscription(Guid userId);
        Task ActivateSubscription(Guid userId);
    }
}
