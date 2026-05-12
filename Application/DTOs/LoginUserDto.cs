namespace Application.DTOs
{
    public record LoginUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string RawPassword { get; set; } = string.Empty;
    }
}
