using Domain.Enums;
using Domain.MethodExtension;

namespace Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; private set; } //Se Asigna en EF DB
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRoles Role { get; private set; }
        
        public UserEntity(string UserName, string Email, string PasswordHash)
        {
            UserName.ThrowIfNullOrEmpty();
            UserName.ThrowIfLimitExceeded(10);
            UserName.ThrowIfNotClearString();

            PasswordHash.ThrowIfNullOrEmpty();

            Email.ThrowIfNullOrEmpty();
            Email.ThrowIfNotValidEmail();
            Email.ThrowIfLimitExceeded(100);

            this.UserName = UserName;
            this.PasswordHash = PasswordHash;
            Role = UserRoles.Guest;
        }

        public void Update(string? UserName, string? Email , UserRoles? Role)
        {
            if(UserName != null)
            {
                UserName.ThrowIfNullOrEmpty();
                UserName.ThrowIfLimitExceeded(20);
                UserName.ThrowIfNotClearString();
            }

            
        }

        public void ChangePassword(string PasswordHash)
        {
            PasswordHash.ThrowIfNullOrEmpty();

            this.PasswordHash = PasswordHash;
        }
    }
}