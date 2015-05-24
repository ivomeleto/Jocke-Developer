namespace TrafalgarSquare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class PostResources
    {
        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public string FileUrl { get; set; }

    }
}
