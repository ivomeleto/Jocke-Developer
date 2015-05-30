using TrafalgarSquare.Models;
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
            var categorieName = "Funny Pictures";

            ViewBag.Title = categorieName;

            // TODO Да се взима Idто на категорията по културен начин
            ViewBag.CategorieId = 2;


            var posts = base.getByCategorieNamePostViewModels(categorieName);

            return this.View("AllCategoriesView", posts);
        }

        [HttpPost]
        public ActionResult PostCreate(PostCreateBindModel post)
        {
            base.BaseForAllCategoriesPostCreat(post);

            return this.RedirectToAction("Index");
        }
    }
}