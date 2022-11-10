using Entities1;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class DataBaseContext1 : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Tags>   Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(
                @"Server=DESKTOP-62N3GQT\MSSQLSERVER2019; 
                Initial Catalog=Ef_QueryData; integrated security=true;
                MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }


}
