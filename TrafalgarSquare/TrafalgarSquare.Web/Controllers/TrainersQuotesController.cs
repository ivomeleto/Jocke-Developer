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

        [Route("TrainersQuotes")]
        public ActionResult Index()
        {
            var categorieName = "Trainers' Quotes";

            ViewBag.Title = categorieName;

            var posts = base.getByCategorieNamePostViewModels(categorieName);

            return this.View("AllCategoriesView", posts);
        }
        
    }
}