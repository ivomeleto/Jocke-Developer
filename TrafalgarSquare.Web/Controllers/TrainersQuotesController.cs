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

        public ActionResult Index()
        {
            return this.View("TrainersQuotesView");
        }
    }
}