using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class JockesController : BaseController
    {
        // GET: Jockes
        public ActionResult Index()
        {
            return View();
        }

        public JockesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}