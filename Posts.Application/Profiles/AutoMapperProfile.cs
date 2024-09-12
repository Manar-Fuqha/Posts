using AutoMapper;
using Posts.Application.Features.Posts.Commands.CreatePost.Models;
using Posts.Application.Features.Posts.Commands.DeletePost.Models;
using Posts.Application.Features.Posts.Commands.UpdatePost.Models;
using Posts.Application.Features.Posts.Queries.GetPostDetail.Response;
using Posts.Application.Features.Posts.Queries.GetPostsList.Models;
using Posts.Application.Features.Posts.Queries.GetPostsList.Response;
using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Post, GetPostsListViewResponse>().ReverseMap();
            CreateMap<Post, GetPostDetailViewResponse>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();

        }
    }
}
