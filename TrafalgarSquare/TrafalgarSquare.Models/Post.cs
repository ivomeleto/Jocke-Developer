namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post
    {
        private ICollection<UsersReportedPosts> reportedUsers;
        private ICollection<UsersPostsLikes> likedUsers;
        private ICollection<PostsComments> comments;

        public Post()
        {
            this.reportedUsers = new HashSet<UsersReportedPosts>();
            this.likedUsers = new HashSet<UsersPostsLikes>();
            this.comments = new HashSet<PostsComments>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public PostContent Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public string PostOwnerId { get; set; }

        public virtual User PostOwner { get; set; }

        public virtual ICollection<UsersReportedPosts> ReportedUsers
        {
            get { return this.reportedUsers; }
            set { this.reportedUsers = value; }
        }

        public virtual ICollection<UsersPostsLikes> LikedUsers
        {
            get { return this.likedUsers; }
            set { this.likedUsers = value; }
        }

        public virtual ICollection<PostsComments> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool? IsReported { get; set; }
    }
}
