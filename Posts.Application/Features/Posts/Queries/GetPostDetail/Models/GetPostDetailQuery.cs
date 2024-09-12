using MediatR;
using Posts.Application.Features.Posts.Queries.GetPostDetail.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Queries.GetPostDetail.Models
{
    public class GetPostDetailQuery : IRequest<GetPostDetailViewResponse>
    {
        public Guid Id {  get; set; }
        public GetPostDetailQuery(Guid id)
        {
            Id = id;
        }
    }
}
