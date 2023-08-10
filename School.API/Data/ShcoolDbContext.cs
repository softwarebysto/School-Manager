using Microsoft.EntityFrameworkCore;
using School.API.Entities;

namespace School.API.Data
{
    public class ShcoolDbContext:DbContext
    {

        public ShcoolDbContext(DbContextOptions<ShcoolDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Schools>().HasData(new Schools
            {
                id=1,
                region_name="Tashkent",
                school_name="124-School"
            });
            modelBuilder.Entity<Schools>().HasData(new Schools
            {
                id=2,
                region_name="Tashkent",
                school_name="123-School"
            });

            modelBuilder.Entity<School.API.Entities.School>().HasData(new School.API.Entities.School
            {
                id=1,
                school_name="124-School",
                classes =null,
            });
            modelBuilder.Entity<School.API.Entities.School>().HasData(new School.API.Entities.School
            {
                id=2,
                school_name="123-School",
                classes = null,
            });

        }
        public DbSet<Schools> schools { get; set; }
        public DbSet<School.API.Entities.School> school { get; set; }
    }

}
