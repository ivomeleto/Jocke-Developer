
using TrafalgarSquare.Models;

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
        public JokesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [Route("jokes")]
        public ActionResult Index()
        {
            ViewBag.Title = "Jokes";

            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals("Jokes"))
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

            return this.View("AllCategoriesView", posts);
        }

        /* public ActionResult GetPostById(int id)
         {
             var posts = Data.Posts.All()
                 .Where(p => p.Category.Name.Equals("Jokes"))
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
                 .FirstOrDefault(post => post.Id == id);

             return this.View(posts);
         }    */


    }
}