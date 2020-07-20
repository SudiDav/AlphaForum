using System.Collections.Generic;
using System.Linq;
using AlphaForum.Data;
using AlphaForum.Data.Models;
using AlphaForum.Web.ViewModels.Posts;
using AlphaForum.Web.ViewModels.Reply;
using Microsoft.AspNetCore.Mvc;

namespace AlphaForum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;

        public PostController(IPost post)
        {
            _post = post;
        }

        public IActionResult Index(int id)
        {
            var post = _post.GetById(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }

        private IEnumerable<PostReplyViewModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyViewModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}