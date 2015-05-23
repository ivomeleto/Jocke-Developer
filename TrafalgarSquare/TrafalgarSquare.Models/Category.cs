namespace TrafalgarSquare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
