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

            // TODO Да се взима Idто на категорията по културен начин
            ViewBag.CategorieId = 4;

            var posts = base.getByCategorieNamePostViewModels(categorieName);

            return this.View("AllCategoriesView", posts);
        }

        [HttpPost]
        public ActionResult PostCreate(PostCreateBindModel post)
        {
            base.BaseForAllCategoriesPostCreat(post);

            return this.RedirectToAction("Index");
        }
       
    }
}