using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.SubscriptionPlanModels;

namespace LanguageExchange.Application.Services.SubscriptionPlanServices
{
    public interface ISubscriptionPlanService
    {
        Task<ResultViewModel<IList<SubscriptionPlanViewModel>>> GetAllPlans();
        Task<ResultViewModel<SubscriptionPlanViewModel>> GetPlanById(Guid id);
        Task<ResultViewModel<Guid>> CreatePlan(CreateSubscriptionPlanInputModel model);
        Task<ResultViewModel<int>> UpdateSubscriptionPlan(Guid id, UpdateSubscriptionPlanInputModel model);
        Task<ResultViewModel<int>> DeleteSubscriptionPlan(Guid id);
    }
}
