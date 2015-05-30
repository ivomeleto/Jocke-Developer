using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;
using TrafalgarSquare.Web.ViewModels;

namespace TrafalgarSquare.Web.Controllers
{
    public class CategoriesAllController : BaseController
    {
        public CategoriesAllController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [Authorize]
        [Route("Categories/EditorForPosts")]
        public ActionResult EditorPosts()
        {
            return this.View("CreatePostView");
        }

       
       
    }
}