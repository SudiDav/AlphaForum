using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaForum.Data;
using AlphaForum.Data.Models;
using AlphaForum.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace AlphaForum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                .Include(post => post.Forum)
                .Include(post => post.User)
                .Include(post => post.Replies)
                .ThenInclude(reply => reply.User)
                .FirstOrDefault();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForumId(int id)
        {
            return _context.Forums.First(forum => forum.Id == id).Posts;
        }

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string content)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }
    }
}