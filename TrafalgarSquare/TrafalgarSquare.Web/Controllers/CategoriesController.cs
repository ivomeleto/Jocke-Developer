namespace TrafalgarSquare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TrafalgarSquare.Data;

    public class CategoriesController : BaseController
    {
        public CategoriesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        // GET: Categories
        public ActionResult Index()
        {
            return this.View();
        }
    }
}