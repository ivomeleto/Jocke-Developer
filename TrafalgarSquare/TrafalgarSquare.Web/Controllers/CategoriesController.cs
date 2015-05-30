using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;
using TrafalgarSquare.Web.ViewModels;

namespace TrafalgarSquare.Web.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        public CategoriesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [HttpGet]
        [Route("Categories/EditorForPosts")]
        public ActionResult EditorPosts()
        {
            return this.View("CreatePostView");
        }

        [HttpPost]
        public ActionResult PostCreate(PostCreateBindModel post)
        {
            base.BaseForAllCategoriesPostCreat(post);

            return this.Redirect("/");
        }

        [HttpDelete]
        [Route("Categories/DeletePost/{postId}")]
        public ActionResult EditorPosts(int postId)
        {
            base.DeletePostInCategorie(postId);

            return this.Redirect("/");
        }

       
       
    }
}