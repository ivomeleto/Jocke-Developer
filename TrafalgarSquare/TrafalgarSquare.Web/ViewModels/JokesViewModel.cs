namespace TrafalgarSquare.Web.ViewModels
{
    using System;
    using Models;

    public class JokesViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Likes { get; set; }
        public bool IsReported { get; set; }
        public string UserId { get; set; }
        public PostResources Resource { get; set; }
        public int CommentsCount { get; set; }
    }
}