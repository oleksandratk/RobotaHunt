using Microsoft.EntityFrameworkCore;
using RobotaHunt.Core.Models;

namespace RobotaHunt.Core.Data
{
    public class RobotaHuntDbContext : DbContext
    {
        public RobotaHuntDbContext(DbContextOptions<RobotaHuntDbContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(v => v.Vacancies);
            modelBuilder
                .Entity<Vacancy>()
                .HasOne(c => c.Company)
                .WithMany(v => v.Vacancies)
                .HasForeignKey(i => i.CompanyId);
            
            /*modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = 1,
                    Title = "Starbucks",
                    VacanciesCount = 2
                }, 
                new Company()
                {
                    Id = 2,
                    Title = "Paul",
                    VacanciesCount = 3
                });
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy()
                {
                    Id = 1,
                    Title = "Barista",
                    Description = "Make good coffee and differentiate americano with espresso.",
                    CompanyId = 1
                },
                new Vacancy()
                {
                    Id = 2,
                    Title = "Super Barista",
                    Description = "Make good coffee and differentiate arabica and robusta.",
                    CompanyId = 2
                },
                new Vacancy()
                {
                    Id = 3,
                    Title = "Waiter",
                    Description = "Serving and avoiding arguing with clients.",
                    CompanyId = 1
                },
                new Vacancy()
                {
                    Id = 4,
                    Title = "Waiter",
                    Description = "Smile to people and avoid arguing with clients.",
                    CompanyId = 2
                },
                new Vacancy()
                {
                    Id = 5,
                    Title = "Delivery guy",
                    Description = "Bringing coffee and sweets to lazy customers who order food delivery to home.",
                    CompanyId = 2
                });*/
        }
    }
}