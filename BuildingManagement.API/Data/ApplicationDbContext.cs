using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BuildingManagement.API.Data.Entity;

namespace BuildingManagement.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //All Table DB set

        #region DB SET Building
        public DbSet<Building> Building { get; set; }
        public DbSet<Objects> Objects { get; set; }
        public DbSet<DataField> DataField { get; set; }
        public DbSet<Reading> Reading { get; set; }
        #endregion

        #region DB Query Building

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }

                );
        }
    }
}
