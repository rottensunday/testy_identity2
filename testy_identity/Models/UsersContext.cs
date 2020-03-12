using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testy_identity.Models;

namespace testy_identity.Models
{
    public class UsersContext : IdentityDbContext<User>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserGroup>().HasKey(ug => new { ug.UserID, ug.GroupID });
            builder.Entity<UserGroup>().HasOne(g => g.Group).WithMany(ug => ug.UserGroups).HasForeignKey(ug => ug.GroupID);
            builder.Entity<UserGroup>().HasOne(g => g.User).WithMany(us => us.UserGroups).HasForeignKey(ug => ug.UserID);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public async Task AddUserToGroupAsync(User user, Group group)
        {
            if(user == null || group == null)
            {
                return;
            }
            await UserGroups.AddAsync(new UserGroup() { Group = group, User = user });
            await SaveChangesAsync();
        }
    }
}
