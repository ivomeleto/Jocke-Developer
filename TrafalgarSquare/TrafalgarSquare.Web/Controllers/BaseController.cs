namespace TrafalgarSquare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TrafalgarSquare.Data;
    using TrafalgarSquare.Models;

    public abstract class BaseController : Controller
    {
        private ITrafalgarSquareData data;

        protected BaseController(ITrafalgarSquareData data)
        {
            this.Data = data;
        }

        protected ITrafalgarSquareData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
    }
}