using Microsoft.EntityFrameworkCore;
using Posts.Application.Contracts;
using Posts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly PostDBContext dBContext;

        public PostRepository(PostDBContext dBContext) : base(dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            var posts = includeCategory ? await dBContext.posts.Include(x => x.Category).ToListAsync() 
                : await dBContext.posts.ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            var post = includeCategory?await dBContext.posts.Include(x => x.Category).FirstOrDefaultAsync(x=>x.Id==id) 
                : await dBContext.posts.FirstOrDefaultAsync(x => x.Id == id);

            return post;
        }
    }
}
