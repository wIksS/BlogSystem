using AutoMapper;
using BlogSystem.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Areas.Administration.ViewModels
{
    public class BlogPostViewModel : IHaveCustomMappings
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public String Category { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostViewModel>()
                .ForMember(p => p.Category, opt => opt.MapFrom(b => b.Category.Title))
                .ReverseMap();
        }
    }
}