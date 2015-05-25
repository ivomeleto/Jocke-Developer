using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafalgarSquare.Web.Controllers
{
    using Automapper;
    using Models;

    public class UserViewModel:IMapFrom<User>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
    }
}