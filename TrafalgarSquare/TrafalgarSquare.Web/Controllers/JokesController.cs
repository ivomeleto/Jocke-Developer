namespace TrafalgarSquare.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using ViewModels;

    public class JokesController : BaseController
    {
        private readonly ITrafalgarSquareData _data;

        // GET: Jockes
        public ActionResult Index()
        {
            var posts = _data.Posts.All()
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
                    Username = p.PostOwner.UserName,
                    UserId = p.PostOwnerId,
                    CommentsCount = p.Comments.Count()
                })
                .ToList();
            return View(posts);
        }

        public JokesController(ITrafalgarSquareData data) : base(data)
        {
            _data = data;
        }
    }
}