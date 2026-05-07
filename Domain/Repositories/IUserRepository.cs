namespace Domain.Repositories
{
    public interface IUserRepository   
    {
        Task<bool> HasExistsByEmailAsync(string email);
        Task<bool> HasExistsByIdAsync(Guid id);
    }   
}
