using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class Subscription
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public PlanEnum Plan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public StatusSubscriptionEnum Status { get; private set; }

        //TODO - Implementar métodos
        public void RenewSubscription() { }
        public void CancelSubscription() { }
    }
}
