using FluentValidation;
using Posts.Application.Features.Posts.Commands.CreatePost.Models;

namespace Posts.Application.Features.Posts.Commands.CreatePost.Validations
{
    public class CreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValidator()
        {

            RuleFor(p=>p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Content)
                .NotNull()
                .NotEmpty();
        }
    }
}
