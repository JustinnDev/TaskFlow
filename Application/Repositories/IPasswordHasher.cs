namespace Application.Repositories
{
    public interface IPasswordHasher
    {
        string HashAsync(string rawPassword);
        bool VerifyAsync(string rawPassword, string storedHash);
    }
}
