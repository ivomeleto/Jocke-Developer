namespace TrafalgarSquare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UsersFriends
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Friend")]
        public string FriendId { get; set; }

        public virtual User Friend { get; set; }

        public DateTime? SentFriendRequestDate { get; set; }

        public bool? IsAccepted { get; set; }

        public DateTime? FriendsFromDate { get; set; }

    }
}
