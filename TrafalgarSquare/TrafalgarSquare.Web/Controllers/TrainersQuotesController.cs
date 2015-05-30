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

    public class TrainersQuotesController : BaseController
    {
        public TrainersQuotesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [Route("TrainersQuotes/{PageFromUrl}")]
        public ActionResult Index(int? PageFromUrl)
        {

            var Page = PageFromUrl == null ? 1 : PageFromUrl;  Page = PageFromUrl;

            if (Page <= 0)
            {
                Page = 1;
            }

            var categorieName = "Trainers' Quotes";
            
            ViewBag.Title = categorieName;
            ViewBag.CategorieNameWithOutSpaces = "TrainersQuotes";

            // TODO Да се взима Idто на категорията по културен начин
            ViewBag.CategorieId = 1;
            var PageSize = 1;
            ViewBag.PagePrevious = Page - 1;
            ViewBag.PageNext = Page + 1;

            var posts = base.getPostViewModelByCategorieNamePageAndPageSize(categorieName, (int)Page, PageSize);

            return this.View("AllCategoriesView", posts);
        }

        
    }
}