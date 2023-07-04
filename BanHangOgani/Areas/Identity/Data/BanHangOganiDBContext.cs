using BanHangOgani.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BanHangOgani.Data;

public class BanHangOganiDBContext : IdentityDbContext<ApplicationUser>
{
    public BanHangOganiDBContext(DbContextOptions<BanHangOganiDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        string id_role = Guid.NewGuid().ToString();
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = id_role,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR".ToUpper()
        });

        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<IdentityUser>();
        //Seeding the User to AspNetUsers table
        string id_user = Guid.NewGuid().ToString();
        builder.Entity<ApplicationUser>().HasData(
        new ApplicationUser
        {
            Id = id_user, // primary key
            UserName = "admin@gmail.com",
            FirstName = "admin",
            LastName = "admin",

            PhoneNumber = "1234567890",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            PasswordHash = hasher.HashPassword(null, "123456")
        }
        );
        //Seeding the relation between our user and role to AspNetUserRoles table
        builder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
            RoleId = id_role,
            UserId = id_user
        }
        );
    }
}
