using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.SubscriptionPlanModels;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.SubscriptionPlanServices
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly ISubscriptionPlanRepository _repository;
        public SubscriptionPlanService(ISubscriptionPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> CreatePlan(CreateSubscriptionPlanInputModel model)
        {
            var plan = model.ToEntity();
            var result = await _repository.CreateSubscriptionPlan(plan);
            if (result > 0)
                return ResultViewModel<int>.Error("Error to create subscription plan");
            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel<int>> DeleteSubscriptionPlan(Guid id)
        {
            var result = await _repository.DeleteSubscriptionPlan(id);
            if (result > 0)
                return ResultViewModel<int>.Error("Error delete subscription plan.");
            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel<IList<SubscriptionPlanViewModel>>> GetAllPlans()
        {
            var plan = await _repository.GetAllPlans();
            if (plan == null)
                return ResultViewModel<IList<SubscriptionPlanViewModel>>.Error("Error, Don't exist subscription plans.");

            IList<SubscriptionPlanViewModel> result = new List<SubscriptionPlanViewModel>();
            foreach (var item in plan)
            {
                var viewModel = SubscriptionPlanViewModel.FromEntity(item);
                result.Add(viewModel);
            }
            
            return ResultViewModel<IList<SubscriptionPlanViewModel>>.Success(result);
        }

        public async Task<ResultViewModel<SubscriptionPlanViewModel>> GetPlanById(Guid id)
        {
            var plan = await _repository.GetPlanById(id);
            if (plan == null)
                return ResultViewModel<SubscriptionPlanViewModel>.Error("Error, Subscription plans not found.");

            SubscriptionPlanViewModel result = new SubscriptionPlanViewModel();
            result = SubscriptionPlanViewModel.FromEntity(plan);

           
            return ResultViewModel<SubscriptionPlanViewModel>.Success(result);
        }

        public async Task<ResultViewModel<int>> UpdateSubscriptionPlan(Guid id, UpdateSubscriptionPlanInputModel model)
        {
            var UpdateModel = model.ToEntity();
            var result = await _repository.UpdateSubscriptionPlan(id, UpdateModel);
            if (result > 0)
                return ResultViewModel<int>.Error("Error to update subscription plans.");

            return ResultViewModel<int>.Success(result);
        }
    }
}
