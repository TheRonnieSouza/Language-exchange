using System;

namespace LanguageExchange.Core.Entities
{
    public class SubscriptionPlan
    {
        public SubscriptionPlan() { }
        public SubscriptionPlan(string name, decimal price, string currency, 
            TimeSpan duration,string features)
            {
                Name = name;
                Price = price;
                Currency = currency;
                Duration = duration;
                Features = features;
            }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Currency { get; private set; }
        public TimeSpan Duration { get; private set; }
        public bool IsActive { get; private set; } =true;
        public string Features { get; private set; }
        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        //TODO - Implementar métodos
        public void Activate() { IsActive = true; }
        public void Desactivate() { IsActive = false; }
        public (bool, string) UpdatePrice(decimal newPrice) 
        {
            if (newPrice > 0)
            {
                Price = newPrice;
                return (true, "Price updated successfully");
            }
            else
            {
                return (false, "The price must be greater then 0!");
            }
                
        }
        public void Update(string name, decimal price, string currency, TimeSpan duration, string features)
        {
            Name = name; Price = price;Currency = currency; Duration = duration; Features = features;
        }
    }
}
