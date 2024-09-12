using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Commands.DeletePost.Models
{
    public class DeletePostCommand :IRequest
    {
        public Guid PostId { get; set; }
    }
}
