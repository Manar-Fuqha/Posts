using AutoMapper;
using MediatR;
using Posts.Application.Contracts;
using Posts.Application.Features.Posts.Queries.GetPostDetail.Models;
using Posts.Application.Features.Posts.Queries.GetPostDetail.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Queries.GetPostDetail.Handler
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, GetPostDetailViewResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public GetPostDetailQueryHandler(IPostRepository postRepository , IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<GetPostDetailViewResponse> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await postRepository.GetPostByIdAsync(request.Id , true);
            return mapper.Map<GetPostDetailViewResponse>(post); 
        }
    }
}
