using _2020._03._01_Bike_Repository.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace _2020._03._01_Bike_Repository.DAL.Db_Context
{
    public class BicycleStoreDbContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=BicycleStoreDb;Trusted_Connection=True;");
        }
    }
}
