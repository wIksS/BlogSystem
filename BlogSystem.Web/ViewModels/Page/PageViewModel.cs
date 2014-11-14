using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.ViewModels.Page
{
    public class PageViewModel : IMapFrom<BlogSystem.Models.Page>
    {
        public string Title { get; set; }

        public string Content{ get; set; }
    }
}