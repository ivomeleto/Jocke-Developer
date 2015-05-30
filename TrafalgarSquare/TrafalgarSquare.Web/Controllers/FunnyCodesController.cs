using System.Linq;
using TrafalgarSquare.Web.ViewModels;
using TrafalgarSquare.Web.ViewModels.User;

namespace TrafalgarSquare.Web.Controllers
{
    using System.Web.Mvc;
    using Data;

    public class FunnyCodesController : BaseController
    {

        [Route("FunnyCodes")]
        public ActionResult Index()
        {
            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals("Funny Codes"))
                .OrderByDescending(p => p.CreatedDateTime)
                .Select(p => new PostViewModel
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
                .Take(1)
                .ToList();

            return this.View(posts);
        }

        public FunnyCodesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}