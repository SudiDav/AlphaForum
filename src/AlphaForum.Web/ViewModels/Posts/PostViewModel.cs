using AlphaForum.Web.ViewModels.Forums;

namespace AlphaForum.Web.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public ForumViewModel Forum { get; set; }

        public int RepliesCount { get; set; }
    }
}