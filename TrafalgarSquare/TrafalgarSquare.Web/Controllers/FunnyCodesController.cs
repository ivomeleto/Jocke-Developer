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

        [Route("FunnyCodes/{PageFromUrl}")]
        public ActionResult Index(int? PageFromUrl)
        {

            var Page = PageFromUrl == null ? 1 : PageFromUrl;

            if (Page <= 0)
            {
                Page = 1;
            }

            var categorieName = "Funny Codes";
           
            ViewBag.Title = categorieName;
            ViewBag.CategorieNameWithOutSpaces = "FunnyCodes";

            // TODO Да се взима Idто на категорията по културен начин
            ViewBag.CategorieId = 4;
            var PageSize = 1;
            ViewBag.PagePrevious = Page - 1;
            ViewBag.PageNext = Page + 1;

          

            var posts = base.getPostViewModelByCategorieNamePageAndPageSize(categorieName, (int)Page, PageSize);

            return this.View("AllCategoriesView", posts);
        }

 
       
    }
}