using System.Linq;
using TrafalgarSquare.Web.ViewModels;
using TrafalgarSquare.Web.ViewModels.User;

namespace TrafalgarSquare.Web.Controllers
{
    using System.Web.Mvc;
    using Data;

    public class FunnyCodesController : BaseController
    {

        public FunnyCodesController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        [Route("FunnyCodes")]
        public ActionResult Index()
        {
            var categorieName = "Funny Codes";

            ViewBag.Title = categorieName;

            var posts = base.getByCategorieNamePostViewModels(categorieName);

            return this.View("AllCategoriesView", posts);
        }
        

       
    }
}