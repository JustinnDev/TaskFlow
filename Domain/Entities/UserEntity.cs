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

        //Const
        private const short EmailMax = 100;
        private const short UserNameMax = 10;
        
        public UserEntity(string UserName, string Email, string PasswordHash, UserRoles? Role)
        {
            UserName.ThrowIfNullOrEmpty();
            UserName.ThrowIfNotClearString();
            UserName.ThrowIfLimitMax(UserNameMax);

            PasswordHash.ThrowIfNullOrEmpty();

            Email.ThrowIfNullOrEmpty();
            Email.ThrowIfNotValidEmail();
            Email.ThrowIfLimitMax(EmailMax);

            Role.ThrowIfUndefined();

            this.UserName = UserName;
            this.PasswordHash = PasswordHash;
            this.Role = Role ?? UserRoles.Guest;
        }

        public void Update(string? UserName, string? Email , UserRoles? Role)
        {
            if(UserName != null)
            {
                UserName.ThrowIfNullOrEmpty();
                UserName.ThrowIfLimitMax(UserNameMax);
                UserName.ThrowIfNotClearString();

                this.UserName = UserName;
            }

            if(Email != null)
            {
                Email.ThrowIfNullOrEmpty();
                Email.ThrowIfNotValidEmail();
                Email.ThrowIfLimitMax(EmailMax);

                this.Email = Email;
            }

            if(Role != null)
            {
                Role.ThrowIfUndefined();
                this.Role = Role.Value;
            }
        }

        public void ChangePassword(string PasswordHash)
        {
            PasswordHash.ThrowIfNullOrEmpty();

            this.PasswordHash = PasswordHash;
        }
    }
}