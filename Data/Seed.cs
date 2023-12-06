using Microsoft.AspNetCore.Identity;
using ShoeShop.Models;
using ShoeShop.Models.Enum;

namespace ShoeShop.Dao
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                       new Product()
                       {
                           Title="product 1",
                           Description="desciption 1",
                           Category=Category.Sandal,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                                                      CreateDate=DateTime.Now,

                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active
                       },
                       new Product()
                       {
                           Title="product 2",
                           Description="desciption 2",
                           Category=Category.Sandal,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           CreateDate=DateTime.Now,

                           Sale=10,
                           Status=ProductStatus.Active
                       },
                       new Product()
                       {
                           Title="product 3",
                           Description="desciption 3",
                           Category=Category.Sandal,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now,

                       }
                       ,new Product()
                       {
                           Title="product 4",
                           Description="desciption 4",
                           Category=Category.Sneaker,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now,

                       },
                       new Product()
                       {
                           Title="product 5",
                           Description="desciption 5",
                           Category=Category.Sneaker,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now,

                       }
                       ,new Product()
                       {
                           Title="product 6",
                           Description="desciption 6",
                           Category=Category.Sport,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now,

                       }
                       ,
                       new Product()
                       {
                           Title="product 7",
                           Description="desciption 7",
                           Category=Category.Sandal,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now,

                       }
                       ,
                       new Product()
                       {
                           Title="product 8",
                           Description="desciption 8",
                           Category=Category.Casual,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now
                       }
                       ,
                       new Product()
                       {
                           Title="product 9",
                           Description="desciption 9",
                           Category=Category.Casual,
                           Price=2000000,
                           Brand = Brand.Adidas,
                           Gender = Gender.Men,
                           Image = new Image()
                           {
                               First="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Second="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                               Third="https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360"
                           },
                           Quantity=100,
                           Sale=10,
                           Status=ProductStatus.Active,
                           CreateDate=DateTime.Now

                       }

                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "buiquanghuy0029a@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "QuangHuyfs",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "0981722033",
                        UserRoles = UserRoles.Admin,
                        AvatarUrl = "https://scontent.fsgn16-1.fna.fbcdn.net/v/t39.30808-6/270186735_482533609958009_7421940097305099732_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=TxtI1CMAzZ8AX9CHoUT&_nc_ht=scontent.fsgn16-1.fna&oh=00_AfB3KQgT800wX3xBb71bWDvhWbj58CpLGPQal2QqAN8g0A&oe=64A2B5F5",
                        UserStatus = Models.Enums.UserStatus.Active
                    };
                    await userManager.CreateAsync(newAdminUser, "Quanghuy@2002");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


            }
        }

    }
}
