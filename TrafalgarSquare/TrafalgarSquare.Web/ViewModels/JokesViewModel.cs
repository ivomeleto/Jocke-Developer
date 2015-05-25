namespace TrafalgarSquare.Web.ViewModels
{
    using System;
    using Automapper;
    using Controllers;
    using Models;

    public class JokesViewModel:IMapFrom<Post>
    {
        private bool? _isReported;

        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Likes { get; set; }

        public bool? MyProperty
        {
            get { return _isReported; }
            set { _isReported = value ?? false; }
        }
        public UserViewModel PostOwner { get; set; }
        public PostResources Resource { get; set; }
        public int CommentsCount { get; set; }
    }
}