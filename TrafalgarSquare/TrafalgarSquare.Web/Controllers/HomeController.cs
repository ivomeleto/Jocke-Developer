namespace TrafalgarSquare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TrafalgarSquare.Data;
    using TrafalgarSquare.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            // Takes latest Post for each category
            var latestPostByCategory = this.Data.Posts.All()
                .GroupBy(x => x.CategoryId)
                .Select(z => z.OrderByDescending(x => x.CreatedDateTime))
                .SelectMany(x => x.Take(1))
                .GroupJoin(
                    Data.Comments.All(),
                    x => x.Id,
                    postComments => postComments.PostId,
                    (post, postComments) => new
                    {
                        post = post,
                        postComments = postComments.Count()
                    })
                .Select(x => new HomePostViewModel()
                {
                    Id = x.post.Id,
                    Title = x.post.Title,
                    PostResources = x.post.Resource,
                    CreatedDateTime = x.post.CreatedDateTime,
                    PostOwnerId = x.post.PostOwnerId,
                    // TODO: add UserViewModel
                    PostOwner = x.post.PostOwner,
                    CategoryId = x.post.CategoryId,
                    Category = x.post.Category,
                    LikesCount = x.post.LikesPost.Count,
                    CommentsCount = x.postComments,
                });

            var model = new HomeViewModel()
            {
                LatestPostsByCategory = latestPostByCategory,
                TopJokes = this.TopJokes(10)
            };

            return this.View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}