namespace TrafalgarSquare.Web.ViewModels
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