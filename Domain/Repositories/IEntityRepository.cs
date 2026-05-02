namespace Domain.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid entityId);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task SaveAsync();
    }
}
