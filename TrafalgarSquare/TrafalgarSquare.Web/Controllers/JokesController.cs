
namespace TrafalgarSquare.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data;
    using ViewModels;
    using ViewModels.User;

    public class JokesController : BaseController
    {
        [Route("jokes")]
        public ActionResult Index()
        {
            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals("Jokes"))
                .OrderByDescending(p => p.CreatedDateTime)
                .ThenBy(p => p.LikesPost.Count())
                .Select(p => new JokesViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Text = p.Text,
                    Resource = p.Resource,
                    CreatedDateTime = p.CreatedDateTime,
                    IsReported = p.IsReported ?? false,
                    Likes = p.LikesPost.Count(),
                    CommentsCount = p.Comments.Count(),
                    User = new UserViewModel
                    {
                        Id = p.PostOwnerId,
                        Username = p.PostOwner.UserName,
                        AvatarUrl = p.PostOwner.AvatarUrl
                    }
                })
                .ToList();
            return this.View(posts);
        }

        public JokesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}