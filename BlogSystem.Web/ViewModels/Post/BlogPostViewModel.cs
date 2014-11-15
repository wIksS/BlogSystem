using BlogSystem.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.ViewModels.Post
{
    public class BlogPostViewModel : IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<BlogPost,BlogPostViewModel>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(b => b.Category.Title));
        }
    }
}