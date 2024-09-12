using MediatR;
using Posts.Application.Contracts;
using Posts.Application.Features.Posts.Commands.DeletePost.Models;
using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Commands.DeletePost.Handler
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IAsyncRepository<Post> postRepository;

        public DeletePostCommandHandler(IAsyncRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
           var post = await postRepository.GetByIdAsync(request.PostId);
            if (post == null)
            {
                throw new ArgumentNullException("Post is not found");
            }
            await postRepository.DeleteAsync(post);

        }
    }
}
