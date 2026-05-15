namespace Domain.Repositories
{
    public interface IUserRepository   
    {

        Task<Guid?> GetIdBByUsername(string username);
        Task<bool> HasExistsByEmailAsync(string email);
        Task<bool> HasExistsByIdAsync(Guid id);
    }   
}
