using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class FunnyCodesController : BaseController
    {
        // GET: FunnyCodes
        public ActionResult Index()
        {
            return View();
        }

        public FunnyCodesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}