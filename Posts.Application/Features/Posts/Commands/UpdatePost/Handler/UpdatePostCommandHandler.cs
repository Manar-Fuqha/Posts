using AutoMapper;
using MediatR;
using Posts.Application.Contracts;
using Posts.Application.Features.Posts.Commands.UpdatePost.Models;
using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Commands.UpdatePost.Handler
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository , IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = mapper.Map<Post>(request);
            await postRepository.UpdateAsync(post);          
            
        }

      
    }
}
