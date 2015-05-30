using TrafalgarSquare.Web.ViewModels;
using TrafalgarSquare.Web.ViewModels.User;

namespace TrafalgarSquare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TrafalgarSquare.Data;

    public class FunnyPicturesController : BaseController
    {
        public FunnyPicturesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [Route("FunnyPictures")]
        public ActionResult Index()
        {
            ViewBag.Title = "FunnyPictures";

            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals("Funny Pictures"))
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
    }
}