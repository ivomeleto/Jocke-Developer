namespace TrafalgarSquare.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Automapper;
    using TrafalgarSquare.Models;

    public class UserProfileViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string AvatarUrl { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public DateTime RegisterDate { get; set; }

        public int? PostCount { get; set; }

        public int? CommentsCount { get; set; }

        public bool IsOwned { get; set; }

        public bool IsViewerFriend { get; set; }

        public bool IsViewerWaitingAcceptance { get; set; }
    }
}
