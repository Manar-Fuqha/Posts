using Posts.Domain;

namespace Posts.Application.Contracts
{
    public interface IPostRepository :IAsyncRepository<Post>
    {

        Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory);
        Task<Post> GetPostByIdAsync(Guid id , bool includeCategory);

    }
}
