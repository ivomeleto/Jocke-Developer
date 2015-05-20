namespace TrafalgarSquare.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TrafalgarSquare.Data.Migrations;
    using TrafalgarSquare.Models;

    public class TrafalgarSquareDbContext : IdentityDbContext<User>, ITrafalgarSquareDbContext
    {
        public TrafalgarSquareDbContext()
            : base("TrafalgarSquare", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrafalgarSquareDbContext, Configuration>());
        }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<UsersReportedPosts> UsersReportedPosts { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public static TrafalgarSquareDbContext Create()
        {
            return new TrafalgarSquareDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Messages
            modelBuilder.Entity<User>()
                .HasMany(x => x.Messages)
                .WithRequired(x => x.Sender)
                .HasForeignKey(x => x.SenderId);

            // User's Posts
            modelBuilder.Entity<User>()
                .HasMany(x => x.Posts)
                .WithRequired(x => x.PostOwner)
                .HasForeignKey(x => x.PostOwnerId);

            modelBuilder.Entity<Post>()
                .HasOptional(entity => entity.RepliedPost)
                .WithMany(p => p.RepliedPosts)
                .HasForeignKey(s => s.RepliedPostId);

            // Reported Posts by user
            modelBuilder.Entity<User>()
                .HasMany(m => m.ReportedPosts)
                .WithRequired(x => x.Reporter)
                .HasForeignKey(x => x.ReportedUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.ReportedUsers)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
