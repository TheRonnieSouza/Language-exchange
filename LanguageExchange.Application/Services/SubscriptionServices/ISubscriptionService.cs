using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.SubscriptionModels;

namespace LanguageExchange.Application.Services.SubscriptionServices
{
    public interface ISubscriptionService
    {
        Task<ResultViewModel<SubscriptionViewModel>> GetCurrentSubscription(Guid userID);
        Task<ResultViewModel<IList<SubscriptionViewModel>>> GetHistorySubscription(Guid userID);
        Task<ResultViewModel<int>> CreateSubscription(Guid userId, CreateSubscriptionInputModel model);
        Task<ResultViewModel<int>> UpdateSubscription(Guid userId, UpdateSubscriptionInputModel model);
        Task<ResultViewModel<int>> CancelSubscription(Guid userId);

    }
}
