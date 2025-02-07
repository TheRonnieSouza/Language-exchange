using LanguageExchange.Core.Entities;
using Microsoft.Identity.Client;

namespace LanguageExchange.Application.Models.SubscriptionPlanModels
{
    public class SubscriptionPlanViewModel
    {
        public SubscriptionPlanViewModel() { }
        public SubscriptionPlanViewModel(Guid id, string name, decimal price, string currency, TimeSpan duration, string features, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            Currency = currency;
            Duration = duration;
            Features = features;
            IsActive = isActive;
        }

        public Guid Id { get;  set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public TimeSpan Duration { get; set; }
        public string Features { get; set; }
        public bool IsActive { get;  set; }

        public static SubscriptionPlanViewModel FromEntity(SubscriptionPlan item)
        {
            return new SubscriptionPlanViewModel(item.Id, item.Name,
                item.Price, item.Currency, item.Duration, item.Features, item.IsActive);
        }
    }
}
