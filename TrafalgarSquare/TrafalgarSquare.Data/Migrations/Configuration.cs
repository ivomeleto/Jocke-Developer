namespace TrafalgarSquare.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TrafalgarSquare.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrafalgarSquareDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TrafalgarSquareDbContext context)
        {
            // Create Administrator Role
            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));
                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join(", ", roleCreateResult.Errors));
                }
            }

            if (!context.Users.Any())
            {
                var firstUser = new User()
                {
                    Id = "fb2b5291-1cad-4348-91d2-615ecca218e8",
                    PasswordHash = "AKLDc4TLa2zb4FaIfRgJHRr74PqvpTjcKj1rHP6+gr4yGmB9tiKUEC478vXSyM365A==",
                    SecurityStamp = "c05cdbb3-bdf0-49cd-9100-b7b98dff60ee",
                    UserName = "Icakis",
                    Email = "Icakis_87@abv.bg",
                };

                var adminRole = context.Roles.FirstOrDefault(x => x.Name == "Administrator");
                if (adminRole == null)
                {
                    throw new Exception("Invalid user role.");
                }

                var newUserRole = new IdentityUserRole() { RoleId = adminRole.Id, UserId = firstUser.Id };
                firstUser.Roles.Add(newUserRole);

                context.Users.Add(firstUser);
                context.SaveChanges();
            }
        }
    }
}
