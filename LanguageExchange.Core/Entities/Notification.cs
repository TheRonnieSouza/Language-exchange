namespace LanguageExchange.Core.Entities
{
    public class Notification
    {
        /// <summary>
        /// Construtor para criar uma nova notificação.
        /// </summary>
        /// <param name="userId">Identificador do usuário que receberá a notificação.</param>
        /// <param name="message">Conteúdo da mensagem.</param>
        /// <param name="type">Tipo ou canal da notificação (ex.: "Email", "Push", "SMS").</param>
        public Notification(Guid userId, string message, string type)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Message = message;
            Type = type;
            CreatedAt = DateTime.UtcNow;
            IsRead = false;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Message { get; private set; }
        public string Type { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsRead { get; private set; }
        public User User { get; private set; } 

        /// <summary>
        /// Marca a notificação como lida.
        /// </summary>
        public void MarkAsRead()
        {
            IsRead = true;
        }

        /// <summary>
        /// Marca a notificação como não lida.
        /// </summary>
        public void MarkAsUnread()
        {
            IsRead = false;
        }

        /// <summary>
        /// Atualiza o conteúdo da mensagem da notificação.
        /// Útil quando a notificação precisa ser revisada ou reenvia uma mensagem atualizada.
        /// </summary>
        /// <param name="newMessage">Novo conteúdo da mensagem.</param>
        public void UpdateMessage(string newMessage)
        {
            if (string.IsNullOrWhiteSpace(newMessage))
            {
                throw new ArgumentException("A mensagem não pode ser vazia.", nameof(newMessage));
            }
            Message = newMessage;
        }

        /// <summary>
        /// Representa a notificação como uma string para fins de logging ou exibição.
        /// </summary>
        public override string ToString()
        {
            return $"Notification [Id={Id}, UserId={UserId}, Type={Type}, CreatedAt={CreatedAt}, IsRead={IsRead}]: {Message}";
        }
    }
}
