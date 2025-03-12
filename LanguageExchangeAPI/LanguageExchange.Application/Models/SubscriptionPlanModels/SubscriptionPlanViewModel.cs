using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.SubscriptionPlanModels
{
    public class SubscriptionPlanViewModel
    {
        public SubscriptionPlanViewModel() { }
        public SubscriptionPlanViewModel(Guid id, string name, decimal price, string currency, int durationOfDays, string features, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            Currency = currency;
            DurationOfDays = durationOfDays;
            Features = features;
            IsActive = isActive;
        }

        public Guid Id { get;  set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int DurationOfDays { get; set; }
        public string Features { get; set; }
        public bool IsActive { get;  set; }

        public static SubscriptionPlanViewModel FromEntity(SubscriptionPlan item)
        {
            var duration = item.Duration.Days;

            return new SubscriptionPlanViewModel(item.Id, item.Name,
                item.Price, item.Currency, duration, item.Features, item.IsActive);
        }        
    }
}
