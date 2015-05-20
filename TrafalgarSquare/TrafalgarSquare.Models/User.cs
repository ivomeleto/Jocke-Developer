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
        private ICollection<UsersReportedPosts> reportedPosts;


        public User()
        {
            this.messages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
            this.posts = new HashSet<Post>();
            this.reportedPosts = new HashSet<UsersReportedPosts>();
        }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime? Birthday { get; set; }

        public Gender? Gender { get; set; }

        public string Adress { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<UsersReportedPosts> ReportedPosts
        {
            get { return this.reportedPosts; }
            set { this.reportedPosts = value; }
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
