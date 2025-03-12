namespace LanguageExchange.Core.Entities
{
    public class PaymentMethod
    {
        public PaymentMethod(Guid userId, string provider, string paymentToken)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Provider = provider;
            PaymentToken = paymentToken;
            AddedAt = DateTime.UtcNow;
        }
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Provider { get; private set; }
        public string PaymentToken { get; private set; }
        public DateTime AddedAt { get; private set; }       

        public User User { get; private set; }

        /// <summary>
        /// Atualiza o token de pagamento.
        /// </summary>
        /// <param name="newToken">Novo token a ser definido.</param>
        public void UpdatePaymentToken(string newToken)
        {
            if (string.IsNullOrWhiteSpace(newToken))
            {
                throw new ArgumentException("The new token cannot be null or empity.", nameof(newToken));
            }
            PaymentToken = newToken;
        }

        /// <summary>
        /// Verifica se o método de pagamento é válido.
        /// Essa validação pode ser expandida conforme regras de negócio (ex.: token expirado).
        /// </summary>
        /// <returns>Retorna true se o token estiver preenchido; caso contrário, false.</returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(PaymentToken);
        }
    }
}
