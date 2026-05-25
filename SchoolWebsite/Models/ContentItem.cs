using System;

namespace SchoolWebsite.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string BodyHtml { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}
