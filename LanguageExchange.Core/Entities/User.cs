namespace LanguageExchange.Core.Entities
{
    public class User
    {
        public User(string fullName, string email, string passwordHash)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
        }
       
        public Guid Id { get; private set; } = new Guid();
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }       
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool IsActive { get; private set; } = true;

        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();
        public UserAdditionalInformation UserAdditionalInformation { get; private set; }
        public UserAddress UserAddress { get; private set; }
        public ICollection<PaymentMethod> PaymentMethods { get; private set; } = new List<PaymentMethod>();
        public ICollection<PasswordResetToken> PasswordResetTokens { get; private set; } = new List<PasswordResetToken>();
        public ICollection<Notification> Notifications { get; private set; } = new List<Notification>();

        public ICollection<PaymentTransaction> PaymentTransactions { get; private set; } = new List<PaymentTransaction>();

        //TODO - Implementar métodos
        public void Authenticate() { }
        public void UpdateUser() { }
        public void DeleteUser() { IsActive = false; }

        public void UpdateUser(string fullName, string email)
        {
           FullName = fullName;
            Email = email;
        }
    }
}
