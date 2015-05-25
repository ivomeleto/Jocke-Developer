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
                .ThenBy(post => post.LikesPost.Count())
                .Select(post => Mapper.Map<JokesViewModel>(post))
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
                .Select(c => Mapper.Map<CommentViewModel>(c));
            return View(comments);
        }

        public JokesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}