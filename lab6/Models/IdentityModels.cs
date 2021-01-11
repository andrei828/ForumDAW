using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace lab6.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
 
        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Comment> LikedComments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new Initp());

        }

        public DbSet<Engagement> Engagements { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Telemetry> Telemetries { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(); ;

        }

    }
    public class Initp : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext ctx)
        {

            Engagement engagement1 = new Engagement { Likes = 12 };
            Engagement engagement2 = new Engagement { Likes = 2 };
            Engagement engagement3 = new Engagement { Likes = 346 };
            Engagement engagement4 = new Engagement { Likes = 85 };
            Engagement engagement5 = new Engagement { Likes = 87 };
            Engagement engagement6 = new Engagement { Likes = 1234 };
            Engagement engagement7 = new Engagement { Likes = 14 };

            Comment comment1 = new Comment { Content = "my first comment", Engagement = engagement1 };
            Comment comment2 = new Comment { Content = "my second comment", Engagement = engagement2 };
            Comment comment3 = new Comment { Content = "my third comment", Engagement = engagement3 };
            Comment comment4 = new Comment { Content = "my fourth comment", Engagement = engagement4 };
            Comment comment5 = new Comment { Content = "my fifth comment", Engagement = engagement5 };
            Comment comment6 = new Comment { Content = "my sixth comment", Engagement = engagement6 };
            Comment comment7 = new Comment { Content = "my seventh comment", Engagement = engagement7 };

            Post post1 = new Post { Content = "Great ideas", Comments = new List<Comment> { comment1, comment2 } };
            Post post2 = new Post { Content = "Posting a story", Comments = new List<Comment> { comment3, comment4 } };
            Post post3 = new Post { Content = "I'm new here any hints", Comments = new List<Comment> { comment5, comment6 } };
            Post post4 = new Post { Content = "Trying to post something", Comments = new List<Comment> { comment7 } };
            Post post5 = new Post { Content = "Trying to post something", Comments = new List<Comment> {  } };

            Topic topic1 = new Topic { Title = "Dogs on skateboards", Posts = new List<Post> { post1, post2 } };
            Topic topic2 = new Topic { Title = "Technology", Posts = new List<Post> { post3 } };
            Topic topic3 = new Topic { Title = "Students", Posts = new List<Post> { post4 } };
            Topic topic4 = new Topic { Title = "Students", Posts = new List<Post> { post5 } };

            Telemetry telemetry1 = new Telemetry { Region = "Europe" };
            Telemetry telemetry2 = new Telemetry { Region = "America" };
            Telemetry telemetry3 = new Telemetry { Region = "APAC" };

            telemetry1.TotalPosts = 3;
            telemetry1.TotalTopics = 2;
            telemetry1.TotalComments = 6;

            // linking hardocoded data
            comment1.Post = post1;
            comment2.Post = post1;
            comment3.Post = post2;
            comment4.Post = post2;
            comment5.Post = post3;
            comment6.Post = post3;
            comment7.Post = post4;

            post1.Topic = topic1;
            post2.Topic = topic1;
            post3.Topic = topic2;
            post4.Topic = topic3;

            ctx.Engagements.Add(engagement1);
            ctx.Engagements.Add(engagement2);
            ctx.Engagements.Add(engagement3);
            ctx.Engagements.Add(engagement4);
            ctx.Engagements.Add(engagement5);
            ctx.Engagements.Add(engagement6);
            ctx.Engagements.Add(engagement7);

            ctx.Comments.Add(comment1);
            ctx.Comments.Add(comment2);
            ctx.Comments.Add(comment3);
            ctx.Comments.Add(comment4);
            ctx.Comments.Add(comment5);
            ctx.Comments.Add(comment6);
            ctx.Comments.Add(comment7);

            ctx.Posts.Add(post1);
            ctx.Posts.Add(post2);
            ctx.Posts.Add(post3);
            ctx.Posts.Add(post4);
            ctx.Posts.Add(post5);

            ctx.Topics.Add(topic1);
            ctx.Topics.Add(topic2);
            ctx.Topics.Add(topic3);
            ctx.Topics.Add(topic4);

            ctx.Telemetries.Add(telemetry1);
            ctx.Telemetries.Add(telemetry2);
            ctx.Telemetries.Add(telemetry3);

            ctx.SaveChanges();
            
            base.Seed(ctx);
        }
    }
}