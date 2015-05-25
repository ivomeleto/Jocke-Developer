using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

       
    }
}