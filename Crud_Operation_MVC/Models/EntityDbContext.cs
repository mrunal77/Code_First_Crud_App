using Microsoft.EntityFrameworkCore;

namespace Crud_Operation_MVC.Models
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }
        public DbSet<DataEntity> DataEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataEntity>().HasData(new DataEntity {Id = 1, Name = "Monster" },
               new DataEntity { Id = 2, Name = "Ghost" });
        }

    }
}
