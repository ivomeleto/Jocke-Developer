namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsersLikes
    {
        public int Id { get; set; }

        public string LikingUserId { get; set; }

        public virtual User LikingUser { get; set; }

        public int LikedPostId { get; set; }

        public virtual Post LikedPost { get; set; }

        public DateTime LikedDateTime { get; set; }
    }
}
