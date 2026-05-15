using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public class SQLServerCommands
        {
            public readonly string GetUtcDate = "GETUTCDATE()";
        }

        public DbSet<UserEntity> users { get; set; }

        //Const and Readonly
        public readonly string UsersTableName = nameof(users);
        public readonly string CreateAt = "CreateAt";
        public readonly string UpdateAt = "UpdateAt";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            
        }
    }
}
