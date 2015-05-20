namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class PostContent
    {
        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public string FileUrl { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
