using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.SubscriptionPlanModels
{
    public class UpdateSubscriptionPlanInputModel 
    {
        public UpdateSubscriptionPlanInputModel() { }
        public UpdateSubscriptionPlanInputModel(string name, decimal price, string currency, int durationInDays, string features)
        {
            Name = name;
            Price = price;
            Currency = currency;
            DurationInDays = durationInDays;
            Features = features;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int DurationInDays { get; set; }
        public string Features { get; set; }

        public SubscriptionPlan ToEntity()
        {
            var duration = TimeSpan.FromDays(DurationInDays);
            return new SubscriptionPlan(Name, Price, Currency, duration, Features);
        }
    }
}
