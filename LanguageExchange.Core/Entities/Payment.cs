using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class Payment
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public PaymentMethodEnum Method { get; private set; }
        public PaymentMethodStatusEnum Status { get; private set; }
        //TODO - Implementar métodos
        public void ProcessPayment() { }
        public void Refund() { }
    }
}
