namespace Domain.Repositories
{
    public interface IEntityWithOwnerRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Guid ownerId);
    }
}
