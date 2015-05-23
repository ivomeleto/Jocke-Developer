

namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UsersCommentsLikes
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CommentId { get; set; }

        public virtual PostsComments Comment { get; set; }

        public DateTime LikedDateTime { get; set; }
    }
}
