namespace TrafalgarSquare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReportedPosts
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        [Required]
        public string ReportedUserId { get; set; }

        public virtual User Reporter { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public DateTime ReprotedDate { get; set; }
    }
}
