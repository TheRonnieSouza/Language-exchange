
using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.SubscriptionModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel() { }
        public SubscriptionViewModel(Guid userId, Guid subscriptionId, DateTime startDate, DateTime endDate,
                        bool isRecurring, string paymentProviderSubscriptionId,
                        StatusSubscriptionEnum status )
        {
            UserId = userId;
            SubscriptionPlanId = subscriptionId;
            StartDate = startDate;
            EndDate = endDate;
            IsRecurring = isRecurring;
            PaymentProviderSubscriptionId = paymentProviderSubscriptionId;
            Status = status;
        }
        public Guid UserId { get;  set; }
        public Guid SubscriptionPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public string PaymentProviderSubscriptionId { get; set; }
        public StatusSubscriptionEnum Status { get; set; } 
        public static SubscriptionViewModel FromEntity(Subscription result)
        {
            return new(result.UserId, result.SubscriptionPlanId,
                    result.StartDate, result.EndDate, result.IsRecurring,
                    result.PaymentProviderSubscriptionId,result.Status);    
        }
    }
}
