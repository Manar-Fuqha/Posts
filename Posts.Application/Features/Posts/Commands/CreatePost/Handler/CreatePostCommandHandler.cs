using AutoMapper;
using MediatR;
using Posts.Application.Contracts;
using Posts.Application.Features.Posts.Commands.CreatePost.Models;
using Posts.Application.Features.Posts.Commands.CreatePost.Validations;
using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Commands.CreatePost.Handler
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public CreatePostCommandHandler(IMapper mapper , IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = mapper.Map<Post>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            await postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
