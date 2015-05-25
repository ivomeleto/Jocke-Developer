using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafalgarSquare.Data;

namespace TrafalgarSquare.Web.Controllers
{
    public class FunnyPicturesController : BaseController
    {
        public FunnyPicturesController(ITrafalgarSquareData data)
            : base(data)
        {
        }
     
        // GET: FunnyPictures
        public ActionResult Index()
        {
            return View("FunnyPicturesView");
        }   
    }
}