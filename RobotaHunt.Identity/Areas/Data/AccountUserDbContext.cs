using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace RobotaHunt.Identity.Data
{
    public class AccountUserDbContext : IdentityDbContext<AccountUser, AccountRole, Guid, AccountUserLogin, AccountUserRole, AccountUserClaim>
    {
        public AccountUserDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        
        //TODO pick this connection string from configs
        public AccountUserDbContext()
            : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=robota-hunt-identity;Integrated Security=True;MultipleActiveResultSets=true")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<AccountRole>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<AccountUser>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
        }
    }
}
