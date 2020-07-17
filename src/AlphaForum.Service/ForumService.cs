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
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts)
                     .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                    .ThenInclude(f => f.Replies)
                        .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Forum)
                .FirstOrDefault();

            forum.Posts ??= new List<Post>(); //checks for null reference... C#8

            return forum;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}