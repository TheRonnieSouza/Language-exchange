using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class Subscription
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public Guid SubscriptionPlanId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsRecurring { get; private set;}
        public string PaymentProviderSubscriptionId { get; private set; }
        public StatusSubscriptionEnum Status { get; private set; }

        public User User { get; private set; } 
        public SubscriptionPlan SubscriptionPlan { get; private set; } 
        public ICollection<PaymentTransaction> PaymentTransactions { get; private set; } = new List<PaymentTransaction>();

        //TODO - Implementar métodos
        public void RenewSubscription() { }
        public void CancelSubscription() { }
    }
}
