﻿using System;
using System.Collections.Generic;
using AlphaForum.Web.ViewModels.Reply;

namespace AlphaForum.Web.ViewModels.Posts
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }
        public IEnumerable<PostReplyViewModel> Replies { get; set; }
    }
}