using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaForum.Data;
using AlphaForum.Data.Models;
using AlphaForum.Web.ViewModels.Forums;
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

            var post = _post.GetPostsByForumId(id).ToList();
            return View();
        }
    }
}