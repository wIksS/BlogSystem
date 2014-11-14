using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IBlogSystemData data)
        {
            this.Data = data;
        }
        
        protected IBlogSystemData Data { get; set; }
    }
}
