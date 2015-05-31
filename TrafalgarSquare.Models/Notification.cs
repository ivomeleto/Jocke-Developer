﻿namespace TrafalgarSquare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Required]
        [ForeignKey("Recepient")]
        public string RecepientId { get; set; }

        public virtual User Recepient { get; set; }

        public DateTime SendDateTime { get; set; }
    }
}
