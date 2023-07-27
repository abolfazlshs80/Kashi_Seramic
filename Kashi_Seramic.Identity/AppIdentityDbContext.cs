
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Text;
using Kashi_Seramic.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Kashi_Seramic.Identity.Configurations;

namespace Pr_Signal_ir.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
