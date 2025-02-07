using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.SubscriptionPlanModels
{
    public class CreateSubscriptionPlanInputModel
    {
        public CreateSubscriptionPlanInputModel(){}
        public CreateSubscriptionPlanInputModel(string name, decimal price, string currency, TimeSpan duration, string features)
        {
            Name = name;
            Price = price;
            Currency = currency;
            Duration = duration;
            Features = features;
        }

        public string Name { get;   set; }
        public decimal Price { get;   set; }
        public string Currency { get;   set; }
        public TimeSpan Duration { get;   set; }
        public string Features { get;   set; }

        public SubscriptionPlan ToEntity() => new(Name, Price, Currency, Duration, Features);
    }
}
