using System.Collections.Generic;
using AlphaForum.Web.ViewModels.Posts;

namespace AlphaForum.Web.ViewModels.Forums
{
    public class ForumDetailsModel
    {
        public ForumViewModel Forum { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}