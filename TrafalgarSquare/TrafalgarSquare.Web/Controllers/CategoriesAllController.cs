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
    public class CategoriesAllController : BaseController
    {
        public CategoriesAllController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [Route("Categories/EditorForPosts")]
        public ActionResult EditorPosts()
        {
            return this.View("CreatePostView");
        }

        [Route("Categories/DeletePost/{postId}")]
        public ActionResult EditorPosts(int postId)
        {
            base.DeletePostInCategorie(postId);

            return this.Redirect("/");
        }
       
    }
}