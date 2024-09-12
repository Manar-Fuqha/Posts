using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Application.Features.Posts.Queries.GetPostsList.Response
{
    public class GetPostsListViewResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public CategoryDto Category { get; set; }
    }
}
