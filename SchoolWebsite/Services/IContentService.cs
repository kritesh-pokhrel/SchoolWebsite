using SchoolWebsite.Models;

namespace SchoolWebsite.Services
{
    public interface IContentService
    {
        string GetContent(string slug);
        ContentItem? GetById(int id);
        IEnumerable<ContentItem> GetAll();
        void UpdateContent(int id, string bodyHtml);
    }
}
