using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.SubscriptionModels;

namespace LanguageExchange.Application.Services.SubscriptionServices
{
    public interface ISubscriptionService
    {
        Task<ResultViewModel<SubscriptionViewModel>> GetCurrentSubscription(Guid userID);
        Task<ResultViewModel<IList<SubscriptionViewModel>>> GetHistorySubscription(Guid userID);
        Task<ResultViewModel<Guid>> CreateSubscription(Guid userId, CreateSubscriptionInputModel model);
        Task<ResultViewModel<int>> UpdateSubscription(Guid userId, UpdateSubscriptionInputModel model);
        Task<ResultViewModel<int>> CancelSubscription(Guid userId);
        Task<ResultViewModel> ActivateSubscription(Guid userId);
    }
}
