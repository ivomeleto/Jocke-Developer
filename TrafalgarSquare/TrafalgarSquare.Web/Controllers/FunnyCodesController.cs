namespace TrafalgarSquare.Web.Controllers
{
    using System.Web.Mvc;
    using Data;

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