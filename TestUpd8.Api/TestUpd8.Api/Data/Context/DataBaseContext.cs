using Microsoft.EntityFrameworkCore;
using TestUpd8.Api.Data.Mapping;
using TestUpd8.Api.Entities;

namespace TestUpd8.Api.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> clients { get; set; }

        public DataBaseContext()
        {

        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(new ClientMap().Configure);
        }
    }
}
