using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.Payment
{
    public class GetPaymentResultViewModel
    {
        public int Id { get;  set; }
        public int UserId { get;  set; }
        public string UserName { get; set; }
        public decimal Price { get;  set; }
        public DateTime PaymentDate { get;  set; }
        public PaymentMethodEnum Method { get;  set; }
        public PaymentMethodStatusEnum Status { get;  set; }
    }
}
