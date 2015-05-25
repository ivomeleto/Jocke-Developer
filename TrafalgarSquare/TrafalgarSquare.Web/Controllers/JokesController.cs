using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class JokesController : BaseController
    {
        // GET: Jockes
        public ActionResult Index()
        {
            return View();
        }

        public JokesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}