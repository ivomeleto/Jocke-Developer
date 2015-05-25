using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class TrainersQuotesController : BaseController
    {
        // GET: TrainersQuotes
        public ActionResult Index()
        {
            return View("TrainersQuotesView");
        }

        public TrainersQuotesController(ITrafalgarSquareData data) : base(data)
        {
        }
    }
}