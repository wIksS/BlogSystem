﻿using BlogSystem.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Areas.Administration.ViewModels
{
    public class PageViewModel : IMapFrom<Page>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}