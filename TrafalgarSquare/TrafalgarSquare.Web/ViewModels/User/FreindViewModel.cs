namespace TrafalgarSquare.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TrafalgarSquare.Web.Automapper;

    public class FreindViewModel : IMapFrom<Models.User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsAcceptedFriendShip { get; set; }
    }
}