
using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.SubscriptionModels
{
    public class UpdateSubscriptionInputModel
    {
        public Guid SubscriptionPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public string PaymentProviderSubscriptionId { get; set; }
        public StatusSubscriptionEnum Status { get; set; } 
        public Subscription ToEntity() => new(SubscriptionPlanId, StartDate, EndDate, IsRecurring, PaymentProviderSubscriptionId, Status);
     }
}
