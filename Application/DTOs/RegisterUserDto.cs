using Domain.Enums;

namespace Application.DTOs
{
    public record RegisterUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RawPassword { get; set; } = string.Empty;
        public UserRoles? Role { get; set; }
    }
}
