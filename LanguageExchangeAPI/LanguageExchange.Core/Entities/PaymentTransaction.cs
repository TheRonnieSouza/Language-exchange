using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class PaymentTransaction
    {
        public PaymentTransaction(Guid userId, Guid subscriptionId, decimal amount, string currency, string providerTransactionId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SubscriptionId = subscriptionId;
            Amount = amount;
            Currency = currency;
            ProviderTransactionId = providerTransactionId;
            TransactionDate = DateTime.UtcNow;
            Status = PaymentStatusEnum.Pending; 
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public Guid SubscriptionId { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string ProviderTransactionId { get; private set; }
        public PaymentStatusEnum Status { get; private set; }
        public User User { get; private set; }
        public Subscription Subscription { get; private set; }

        /// <summary>
        /// Marca a transação como bem-sucedida e registra a data da transação.
        /// </summary>
        public void MarkSuccessful()
        {
            Status = PaymentStatusEnum.Successful;
            TransactionDate = DateTime.UtcNow;            
        }

        /// <summary>
        /// Marca a transação como falha.
        /// </summary>
        public void MarkFailed()
        {
            Status = PaymentStatusEnum.Failed;
            TransactionDate = DateTime.UtcNow;
            // Adicione lógica adicional, como registrar mensagens de erro, se necessário.
        }
        /// <summary>
        /// Marca a transação como reembolsada.
        /// </summary>
        public void MarkRefund()
        {
            Status = PaymentStatusEnum.Refunded;
            TransactionDate = DateTime.UtcNow;            
        }

        /// <summary>
        /// Tenta reprocessar a transação, reiniciando o status para "Pending".
        /// </summary>
        public void Retry()
        {
            if (Status != PaymentStatusEnum.Successful)
            {
                Status = PaymentStatusEnum.Pending;
                TransactionDate = DateTime.UtcNow;                
            }            
        }

        /// <summary>
        /// Verifica se a transação foi concluída com sucesso.
        /// </summary>
        /// <returns>True se o status for "Successful"; caso contrário, false.</returns>
        public bool IsSuccessful()
        {
            return Status == PaymentStatusEnum.Successful ? true : false;
        }
    }
}
