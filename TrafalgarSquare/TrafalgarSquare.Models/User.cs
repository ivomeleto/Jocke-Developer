namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Message> messages;
        private ICollection<Notification> notifications;
        private ICollection<Post> posts;
        private ICollection<ReportedPosts> reportedPosts;
        private ICollection<PostLikes> likedPosts;
        private ICollection<Comment> comments;
        private ICollection<UserFriends> usersFriends;


        public User()
        {
            this.messages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
            this.posts = new HashSet<Post>();
            this.reportedPosts = new HashSet<ReportedPosts>();
            this.likedPosts = new HashSet<PostLikes>();
            this.comments = new HashSet<Comment>();
            this.usersFriends = new HashSet<UserFriends>();
            this.RegisterDate = DateTime.Now;
        }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime? Birthday { get; set; }

        public Gender? Gender { get; set; }

        public string City { get; set; }

        public DateTime RegisterDate { get; private set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<ReportedPosts> ReportedPosts
        {
            get { return this.reportedPosts; }
            set { this.reportedPosts = value; }
        }


        public virtual ICollection<PostLikes> LikedPosts
        {
            get { return this.likedPosts; }
            set { this.likedPosts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<UserFriends> Friends
        {
            get { return this.usersFriends; }
            set { this.usersFriends = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public int NotificationId { get; set; }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
