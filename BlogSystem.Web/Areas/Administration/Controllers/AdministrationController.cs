using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;
namespace BlogSystem.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        public AdministrationController(IBlogSystemData data)
        {
            this.Data = data;
        }

        protected IBlogSystemData Data { get; set; }
    }
}