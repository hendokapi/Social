namespace Social.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Social.Models;
    using Faker;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Social.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Social.Models.DBContext";
        }

        protected override void Seed(Social.Models.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // add some users
            context.Users.AddOrUpdate(
                new User()
                {
                    UserId = 1,
                    Username = "qwer",
                    Password = "qwer",
                    Email = "qwer@qwer.qwer",
                    Role = "admin",
                },
                new User()
                {
                    UserId = 2,
                    Username = "asdf",
                    Password = "asdf",
                    Email = "asdf@adsf.asdf",
                    Role = "user",
                },
                new User()
                {
                    UserId = 3,
                    Username = "zxcv",
                    Password = "zxcv",
                    Email = "zxcv@zxcv.zxcv",
                    Role = "user",
                },
                new User()
                {
                    UserId = 4,
                    Username = "uiop",
                    Password = "uiop",
                    Email = "uiop@uiop.uiop",
                    Role = "user",
                },
                new User()
                {
                    UserId = 5,
                    Username = "fghj",
                    Password = "fghj",
                    Email = "fghj@fghj.fghj",
                    Role = "user",
                }
            );

            // add some posts
            for (int i = 1; i <= 100; i++)
            {
                context.Posts.AddOrUpdate(
                    new Post()
                    {
                        PostId = i,
                        Contents = Faker.Lorem.Paragraph(2),
                        PostedAt = Faker.Identification.DateOfBirth(),
                        UserId = Faker.RandomNumber.Next(1, 5),
                    }
                );
            }

            // add some like
            for (int iu = 1; iu <= 5; iu++)
            {
                List<int> listPostIds = new List<int> { };
                for (int i = 1; i <= 100; i++)
                {
                    listPostIds.Add(i);
                }

                for (int ip = 1; ip < Faker.RandomNumber.Next(1, 100); ip++)
                {
                    var randomIndex = Faker.RandomNumber.Next(0, listPostIds.Count - 1);
                    var randomPostId = listPostIds[randomIndex];
                    listPostIds.RemoveAt(randomIndex);

                    context.Likes.AddOrUpdate(
                        new Like()
                        {
                            PostId = randomPostId,
                            UserId = iu,
                        }
                    );
                }
            }

            // add some comments
            var cid = 1;
            for (int iu = 1; iu <= 5; iu++)
            {
                for (int ip = 1; ip < Faker.RandomNumber.Next(1, 50); ip++)
                {
                    context.Comments.AddOrUpdate(
                        new Comment()
                        {
                            CommentId = cid,
                            Contents = Faker.Lorem.Sentence(),
                            PostId = Faker.RandomNumber.Next(1, 100),
                            UserId = iu,
                        }
                    );
                    cid++;
                }
            }
        }
    }
}
