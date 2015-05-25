namespace TrafalgarSquare.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class PostResources
    {
        public string PictureUrl { get; set; }

        public string VideoUrl { get; set; }

        public string FileUrl { get; set; }

    }
}
