﻿namespace TheDevBlogsAPI.Models.DTO
{
    public class UpdateBlogRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool Visible { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
