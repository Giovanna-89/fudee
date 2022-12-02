using Fudee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Fudee.Data
{
    public class InfoSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))

                if (dbContext.Database.CanConnect())
                {
                    SeedRoles(dbContext);
                    SeedUsers(dbContext);
                    //SeedRestaurants(dbContext);
                    SeedCategoris(dbContext);
                    //SeedDishes(dbContext);
                    //SeedOpinions(dbContext);
                    //SeedAddresses(dbContext);

                }

        }
        //role w aplikacji
        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            if (!dbContext.Roles.Any(r => r.Name == "admin"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" }).Wait();
            }

            if (!dbContext.Roles.Any(r => r.Name == "restaurator"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "restaurator", NormalizedName = "restaurator" }).Wait();
            }
        }

        //konta użytkowników
        private static void SeedUsers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any(u => u.UserName == "admin@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "admin@fudee.pl",
                    NormalizedUserName = "admin@fudee.pl",
                    Email = "admin@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Jan",
                    LastName = "Pulpecik",
                    Photo = "admin.png",
                    Information = ""

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "admin").Wait();
                dbContext.SaveChanges();

            };

            if (!dbContext.Users.Any(u => u.UserName == "restaurator1@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator1@fudee.pl",
                    NormalizedUserName = "restaurator1@fudee.pl",
                    Email = "restaurator1@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Maja",
                    LastName = "Szpinak",
                    Photo = "user.png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };

            if (!dbContext.Users.Any(u => u.UserName == "restaurator2@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator2@fudee.pl",
                    NormalizedUserName = "restaurator2@fudee.pl",
                    Email = "restaurator2@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Adam",
                    LastName = "Stek",
                    Photo = "person(1).png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };


            if (!dbContext.Users.Any(u => u.UserName == "restaurator3@fudee.pl"))
            {
                var user = new AppUser
                {
                    UserName = "restaurator3@fudee.pl",
                    NormalizedUserName = "restaurator3@fudee.pl",
                    Email = "restaurator3@fudee.pl",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    FirstName = "Malwina",
                    LastName = "Malina",
                    Photo = "person(2).png",
                    Information = "Lorem ipsum dolor sit amet. Eum Quis distinctio ab exercitationem sapiente vel ducimus omnis et quisquam dolor ea dolorem provident."

                };

                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Fudee0!");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(dbContext);
                userStore.CreateAsync(user).Wait();
                userStore.AddToRoleAsync(user, "restaurator").Wait();

                dbContext.SaveChanges();

            };
        }
        //dodawanie danych kategorii
        private static void SeedCategoris(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var kat = new List<Category>
                {

                    new Category { NameCategory = "Kuchnia domowa", Icon = "3.png", DescriptionCategoryy = "Tradycyjna polska kuchnia. Smaczne domowe obiady, jak u mamy." },
                    new Category { NameCategory = "Fast Food", Icon = "2.png", DescriptionCategoryy = "Szybkie smaczne potrawy w stylu amerykańskim." },
                    new Category { NameCategory = "Pizza", Icon = "4.png", DescriptionCategoryy = "Klasyczne danie włoskiej kuchni." },
                    new Category { NameCategory = "Kuchnia azjatycka", Icon = "5.png", DescriptionCategoryy = "Orientalny smak" },
                    new Category { NameCategory = "Kawiarnie", Icon = "1.png", DescriptionCategoryy = "Zawsze jest czas na coś słodkiego." },
                    new Category { NameCategory = "Inne smaki", Icon = "6.png", DescriptionCategoryy = "Wychodząc poza schemat, każdy znajdzie tu coś dla siebie." }
                };
                dbContext.AddRange(kat);
                dbContext.SaveChanges();
            };

        }



    }

}


