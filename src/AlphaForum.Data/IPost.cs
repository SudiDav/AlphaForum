using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaForum.Data.Models;

namespace AlphaForum.Data
{
    public interface IPost
    {
        Post GetById(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetFilteredPosts(string searchQuery);

        IEnumerable<Post> GetPostsByForumId(int id);

        Task Add(Post post);

        Task Delete(int id);

        Task EditPostContent(int id, string content);

        Task AddReply(PostReply reply);
    }
}