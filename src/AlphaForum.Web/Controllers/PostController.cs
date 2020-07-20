using AlphaForum.Data;
using AlphaForum.Web.ViewModels.Posts;
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

            var model = new PostIndexViewModel
            {
            };

            return View();
        }
    }
}