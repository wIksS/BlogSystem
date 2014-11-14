using BlogSystem.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.ViewModels
{
    public class NavigationElement : IMapFrom<BlogSystem.Models.Page>, IMapFrom<Category>
    {
        public string Title { get; set; }
    }
}