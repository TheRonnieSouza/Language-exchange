using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class Payment
    {
        public Payment(string userId, string subscriptionId, decimal amount, string currency, string providerTransactionId)
        {
            Id = Guid.NewGuid();
            UserId = Guid.Parse(userId);
            SubscriptionId = Guid.Parse(subscriptionId);
            Amount = amount;
            Currency = currency;
            ProviderTransactionId = providerTransactionId;
            TransactionDate = DateTime.UtcNow;
            Status = PaymentStatus.Pending; 
        }

        public Payment(string userId, decimal amount,PaymentMethodEnum method)
        {
            UserId = Guid.Parse(userId);
            Method = method;
            Amount = amount;
        }

        public Payment(string userId, decimal amount, DateTime transactionDate, PaymentMethodEnum method, PaymentStatus status)
        {
            UserId = Guid.Parse(userId);
            TransactionDate = transactionDate;
            Amount = amount;
            Method = method;
            Status = status;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public Guid SubscriptionId { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string ProviderTransactionId { get; private set; }
        public PaymentStatus Status { get; private set; }

        public PaymentMethodEnum Method { get; private set; }
        public User User { get; private set; }
        public Subscription Subscription { get; private set; }

        /// <summary>
        /// Marca a transação como bem-sucedida e registra a data da transação.
        /// </summary>
        public void MarkSuccessful()
        {
            Status = PaymentStatus.Successful;
            TransactionDate = DateTime.UtcNow;            
        }

        /// <summary>
        /// Marca a transação como falha.
        /// </summary>
        public void MarkFailed()
        {
            Status = PaymentStatus.Failed;
            TransactionDate = DateTime.UtcNow;
            // Adicione lógica adicional, como registrar mensagens de erro, se necessário.
        }
        /// <summary>
        /// Marca a transação como reembolsada.
        /// </summary>
        public void MarkRefund()
        {
            Status = PaymentStatus.Refunded;
            TransactionDate = DateTime.UtcNow;            
        }

        /// <summary>
        /// Tenta reprocessar a transação, reiniciando o status para "Pending".
        /// </summary>
        public void Retry()
        {
            if (Status != PaymentStatus.Successful)
            {
                Status = PaymentStatus.Pending;
                TransactionDate = DateTime.UtcNow;                
            }            
        }

        /// <summary>
        /// Verifica se a transação foi concluída com sucesso.
        /// </summary>
        /// <returns>True se o status for "Successful"; caso contrário, false.</returns>
        public bool IsSuccessful()
        {
            return Status == PaymentStatus.Successful ? true : false;
        }
    }
}
