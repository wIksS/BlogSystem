using BlogSystem.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.ViewModels
{
    public class PageViewModel : IMapFrom<Page>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        public string Title { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}