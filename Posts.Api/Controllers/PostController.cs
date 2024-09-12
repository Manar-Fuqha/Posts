using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.Application.Features.Posts.Commands.CreatePost.Models;
using Posts.Application.Features.Posts.Commands.DeletePost.Models;
using Posts.Application.Features.Posts.Commands.UpdatePost.Models;
using Posts.Application.Features.Posts.Queries.GetPostDetail.Models;
using Posts.Application.Features.Posts.Queries.GetPostsList.Models;

namespace Posts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok( await mediator.Send(new GetPostListQuery()));
        }

        [HttpGet("{id}" , Name = "GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            return Ok(await mediator.Send(new GetPostDetailQuery(id)));
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand createPostCommand)
        {
            return Ok(await mediator.Send(createPostCommand));
        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommand updatePostCommand)
        {
            await mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}" , Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = id };    
            await mediator.Send(deletePostCommand);
            return NoContent();
        }
    }
}
