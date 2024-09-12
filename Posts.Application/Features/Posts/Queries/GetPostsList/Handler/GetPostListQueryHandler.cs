using AutoMapper;
using MediatR;
using Posts.Application.Contracts;
using Posts.Application.Features.Posts.Queries.GetPostsList.Models;
using Posts.Application.Features.Posts.Queries.GetPostsList.Response;


namespace Posts.Application.Features.Posts.Queries.GetPostsList.Handler
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, List<GetPostsListViewResponse>>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public GetPostListQueryHandler(IPostRepository postRepository , IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetPostsListViewResponse>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await postRepository.GetAllPostsAsync(true);
            return mapper.Map<List<GetPostsListViewResponse>>(allPosts);
        }
    }
}
