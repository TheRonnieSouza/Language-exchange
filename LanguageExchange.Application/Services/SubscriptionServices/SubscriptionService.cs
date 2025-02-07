using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.SubscriptionModels;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.SubscriptionServices
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        public SubscriptionService(ISubscriptionRepository repository)
        { 
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> CancelSubscription(Guid userId)
        {
            var result = await _repository.CancelSubscription( userId);
            if (result > 0)
                return ResultViewModel<int>.Error("Error to cancel subscription.");
            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel<int>> CreateSubscription(Guid userId, CreateSubscriptionInputModel model)
        {
            var activeSubscription = await _repository.GetCurrentSubscription(userId);
            if (activeSubscription == null)
                return ResultViewModel<int>.Error("The user alredy have a subscription.");
            
            var subscription = model.ToEntity();

            var result = await _repository.CreateSubscription(userId, subscription);
            if (result > 0)
                return ResultViewModel<int>.Error("Error to create subscription.");
            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel<SubscriptionViewModel>> GetCurrentSubscription(Guid userId)
        {
            var result  = await _repository.GetCurrentSubscription(userId);

            if (result == null)
                return ResultViewModel<SubscriptionViewModel>.Error("The user don't have a subscription.");

            var subscription = SubscriptionViewModel.FromEntity(result);
            return ResultViewModel<SubscriptionViewModel>.Success(subscription);
        }

        public async Task<ResultViewModel<IList<SubscriptionViewModel>>> GetHistorySubscription(Guid userId)
        {

            var result = await _repository.GetHistorySubscription(userId);

            if (result == null)
                return ResultViewModel<IList<SubscriptionViewModel>>.Error("The user don't have a history of subscription.");

            IList< SubscriptionViewModel > historySubscription = new List<SubscriptionViewModel >();
            foreach (var item in result)
            {
                var viewModel = SubscriptionViewModel.FromEntity(item);
                historySubscription.Add(viewModel);
            }
            
            return ResultViewModel<IList<SubscriptionViewModel>>.Success(historySubscription);
        }

        public async Task<ResultViewModel<int>> UpdateSubscription(Guid userId, UpdateSubscriptionInputModel model)
        {
            var UpdateModel = model.ToEntity();
            var result = await _repository.UpdateSubscription(userId, UpdateModel);
            if (result > 0)
                return ResultViewModel<int>.Error("Error to update subscription.");

            return ResultViewModel<int>.Success(result);
        }
    }
}
