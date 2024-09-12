using MediatR;
using Posts.Application.Features.Posts.Queries.GetPostsList.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Queries.GetPostsList.Models
{
    public class GetPostListQuery :IRequest<List<GetPostsListViewResponse>>
    {
    }
}
