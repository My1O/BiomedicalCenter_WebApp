using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BiomedicalWebApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Crear ROLES
            List<IdentityRole> roles = new()
            {
                new IdentityRole{ Name = "Administrador", NormalizedName = "ADMINISTRADOR" },
                new IdentityRole { Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole{ Name = "Desarrollador", NormalizedName = "DESARROLLADOR" }
                
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            //Crear USUARIOS
            List<ApplicationUser> users = new()
            {
                new ApplicationUser
                {
                    UserName = "martinezjohnny@El.com",
                    NormalizedUserName = "MARTINEZJOHNNY@EL.COM",
                    Email = "martinezjohnny@El.com",
                    NormalizedEmail = "MARTINEZJOHNNY@EL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "Rcairo@09.com",
                    NormalizedUserName = "RCAIRO@09.COM",
                    Email = "Rcairo@09.com",
                    NormalizedEmail = "RCAIRO@09.COM",
                    EmailConfirmed = true
                },

                new ApplicationUser
                {
                    UserName = "cCastro@10.com",
                    NormalizedUserName = "CCASTRO@10.COM",
                    Email = "Rcairo@09.com",
                    NormalizedEmail = "RCAIRO@09.COM",
                    EmailConfirmed = true
                }
                
            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            //Agregar contraseña a los usuarios
            var hasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = hasher.HashPassword(users[0], "pA$$1234");
            users[1].PasswordHash = hasher.HashPassword(users[1], "pA$$1234");
            users[2].PasswordHash = hasher.HashPassword(users[1], "cc102020");


            //Agregar roles a usuario
            List<IdentityUserRole<string>> userRoles = new();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(x => x.Name.Equals("Administrador")).Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(x => x.Name.Equals("Supervisor")).Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(x => x.Name.Equals("Desarrollador")).Id
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }

    }
}
