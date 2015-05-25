namespace TrafalgarSquare.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data;
    using ViewModels;

    public class JokesController : BaseController
    {
        [Route("jokes")]
        public ActionResult Index()
        {
            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals("Jockes"))
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
            return View(posts);
        }

        [HttpGet]
        [Route("jokes/comments/{postId}")]
        public ActionResult Comments(int postId)
        {
            var comments = Data.Comments.All()
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    CreatedOn = c.CreatedOn,
                    Text = c.Text,
                    User = new UserViewModel
                    {
                        Id = c.UserId,
                        Username = c.User.UserName,
                        AvatarUrl = c.User.AvatarUrl
                    }
                })
                .ToList();

            return View(comments);
        }

        public JokesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}