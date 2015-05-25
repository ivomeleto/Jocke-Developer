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

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category()
                {
                    Name = "Trainers' Quotes"
                });

                context.Categories.Add(new Category()
                {
                    Name = "Funny Pictures"
                });

                context.Categories.Add(new Category()
                {
                    Name = "Jockes"
                });

                context.Categories.Add(new Category()
                {
                    Name = "Funny Codes"
                });

                context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                // -------------------------------- First User -----------------------------------------
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

                // Add Posts
                var firstUserPost1 = new Post()
                {
                    Title = "First User Post",
                    Text = "Somebody said something.",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = firstUser,
                    PostOwnerId = firstUser.Id,
                    CreatedDateTime = DateTime.Now.AddDays(-12),
                    CategoryId = 1,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 1)
                };
                firstUser.Posts.Add(firstUserPost1);


                var firstUserPost2 = new Post()
                {
                    Title = "First User Post2",
                    Text = "Somebody said something.",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = firstUser,
                    PostOwnerId = firstUser.Id,
                    CreatedDateTime = DateTime.Now,
                    CategoryId = 1,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 1)
                };
                firstUser.Posts.Add(firstUserPost2);

                // Add Comments
                firstUserPost2.Comments.Add(new Comment()
                {
                    PostId = firstUserPost2.Id,
                    Post = firstUserPost2,
                    Text = "Hello, First user comment from himself.",
                    UserId = firstUser.Id,
                    User = firstUser,
                    CreatedOn = DateTime.Now.AddHours(1),
                });

                // Like Posts
                firstUserPost2.LikesPost.Add(new PostLikes()
                {
                    PostId = firstUserPost2.Id,
                    Post = firstUserPost2,
                    UserId = firstUser.Id,
                    User = firstUser,
                    LikedDateTime = DateTime.Now.AddSeconds(22)
                });

                // -------------------------------- Second User -----------------------------------------
                var secondUser = new User()
                {
                    Id = "85e8789c-99cf-4dd9-8d18-fa3884a5da85",
                    PasswordHash = "AD8UyzpQ34ZFLyN0L3E98fNgWgQR33DvcCBmI2gbpv92qR2rmechpYcwOCglzOVUkA==",
                    SecurityStamp = "79089894-1067-4682-adcf-7508969b5836",
                    UserName = "Penka",
                    Email = "penka23@abv.bg",
                };

                // Add Posts
                var secondUserPost1 = new Post()
                {
                    Title = "Second User Post1",
                    Text = "Somebody said something...",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = secondUser,
                    PostOwnerId = secondUser.Id,
                    CreatedDateTime = DateTime.Now.AddHours(-17),
                    CategoryId = 2,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 2)
                };

                secondUser.Posts.Add(secondUserPost1);

                var secondUserPost2 = new Post()
                {
                    Title = "Second User Post2",
                    Text = "Somebody said something.",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = secondUser,
                    PostOwnerId = secondUser.Id,
                    CreatedDateTime = DateTime.Now.AddHours(-2),
                    CategoryId = 1,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 1)
                };

                secondUser.Posts.Add(secondUserPost2);

                // Add Comments
                firstUserPost1.Comments.Add(new Comment()
                {
                    PostId = firstUserPost1.Id,
                    Post = firstUserPost1,
                    Text = "Hello, First user comment from second user.",
                    UserId = secondUser.Id,
                    User = secondUser,
                    CreatedOn = DateTime.Now,
                });

                // Like Posts
                firstUserPost2.LikesPost.Add(new PostLikes()
                {
                    PostId = firstUserPost2.Id,
                    Post = firstUserPost2,
                    UserId = secondUser.Id,
                    User = secondUser,
                    LikedDateTime = DateTime.Now.AddSeconds(123)
                });


                // -------------------------------- Third User -----------------------------------------
                var thirdUser = new User()
                {
                    Id = "b5f94f44-8d1e-44f9-9676-cfe546297974",
                    PasswordHash = "ADhsENyN8sp7QU3Lh+m8tWRL78UpX4IJW6l0z7GlvwSH7ZColZ16rmH8GMQKmNn+Og==",
                    SecurityStamp = "c4933bb9-3645-44d0-bd41-1453ffbf072e",
                    UserName = "Stavri",
                    Email = "ss@abv.bg",
                };

                // Add Posts
                thirdUser.Posts.Add(new Post()
                {
                    Title = "Third User Post1",
                    Text = "Somebody said something...",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = thirdUser,
                    PostOwnerId = thirdUser.Id,
                    CreatedDateTime = DateTime.Now.AddHours(-123),
                    CategoryId = 3,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 3)
                });

                thirdUser.Posts.Add(new Post()
                {
                    Title = "Third User Post2",
                    Text = "Somebody said something.",
                    Resource = new PostResources()
                    {
                        PictureUrl = "http://gravatar.com/avatar/658f2039885a85cc03cc31e20919bed6?s=512"
                    },
                    PostOwner = thirdUser,
                    PostOwnerId = thirdUser.Id,
                    CreatedDateTime = DateTime.Now.AddHours(-2),
                    CategoryId = 1,
                    Category = context.Categories.FirstOrDefault(x => x.Id == 1)
                });

                context.Users.Add(firstUser);
                context.Users.Add(secondUser);
                context.Users.Add(thirdUser);
                context.SaveChanges();
            }
        }
    }
}
