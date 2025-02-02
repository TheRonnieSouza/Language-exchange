namespace LanguageExchange.Core.Entities
{
    public class PasswordResetToken
    {
        /// <summary>
        /// Construtor para inicializar um novo token de reset de senha.
        /// </summary>
        /// <param name="userId">O identificador do usuário.</param>
        /// <param name="token">O valor do token.</param>
        /// <param name="expirationDate">A data/hora de expiração do token.</param>
        public PasswordResetToken(Guid userId, string token, DateTime expirationDate)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Token = token;
            ExpirationDate = expirationDate;
            IsUsed = false;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsUsed { get; private set; }

        public User User { get; private set; }
        

        /// <summary>
        /// Verifica se o token expirou com base na data/hora atual.
        /// </summary>
        /// <returns>True se o token estiver expirado; caso contrário, false.</returns>
        public bool IsExpired()
        {
            return DateTime.UtcNow > ExpirationDate;
        }

        /// <summary>
        /// Marca o token como utilizado.
        /// </summary>
        /// Retorna false se o token já tiver sido utilizado.
        /// Lançada se o token já tiver sido utilizado.
        /// </exception>
        public bool MarkAsUsed()
        {
            if (IsUsed)
                return false;
            IsUsed = true;
            return true;
        }

        /// <summary>
        /// Verifica se o token é válido, ou seja, não foi usado e ainda não expirou.
        /// </summary>
        /// <returns>True se o token for válido; caso contrário, false.</returns>
        public bool IsValid()
        {
            return !IsUsed && !IsExpired();
        }
    }

}
