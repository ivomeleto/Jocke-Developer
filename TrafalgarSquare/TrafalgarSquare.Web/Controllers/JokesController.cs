
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
            var categorieName = "Jokes";
            ViewBag.Title = categorieName;

            // TODO Да се взима Idто на категорията по културен начин
            ViewBag.CategorieId = 3;

            var posts = base.getByCategorieNamePostViewModels(categorieName);

            return this.View("AllCategoriesView", posts);
        }

        [HttpPost]
        public ActionResult PostCreate(PostCreateBindModel post)
        {
            base.BaseForAllCategoriesPostCreat(post);

            return this.RedirectToAction("Index");
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