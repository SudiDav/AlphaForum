using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaForum.Data;
using AlphaForum.Data.Models;
using AlphaForum.Web.ViewModels.Forums;
using AlphaForum.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;

namespace AlphaForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forum;
        private readonly IPost _post;

        public ForumController(IForum forum)
        {
            _forum = forum;
        }

        public IActionResult Index()
        {
            var forums = _forum.GetAll()
                    .Select(forum => new ForumViewModel
                    {
                        Id = forum.Id,
                        Name = forum.Title,
                        Description = forum.Description
                    });
            var model = new ForumIndexViewModel
            {
                ForumView = forums
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var forum = _forum.GetById(id);

            var posts = forum.Posts;

            var postVM = posts.Select(post => new PostViewModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumViewModel(post)
            });

            var model = new ForumDetailsModel
            {
                Posts = postVM,
                Forum = BuildForumViewModel(forum)
            };

            return View(model);
        }

        private ForumViewModel BuildForumViewModel(Post post)
        {
            var forum = post.Forum;

            return BuildForumViewModel(forum);
        }

        private ForumViewModel BuildForumViewModel(Forum forum)
        {
            return new ForumViewModel
            {
                Id = forum.Id,
                ImageUrl = forum.ImageUrl,
                Name = forum.Title,
                Description = forum.Description
            };
        }
    }
}