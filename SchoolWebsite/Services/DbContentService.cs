using System.Collections.Generic;
using System.Linq;
using SchoolWebsite.Data;
using SchoolWebsite.Models;

namespace SchoolWebsite.Services
{
    public class DbContentService : IContentService
    {
        private readonly AppDbContext _db;

        public DbContentService(AppDbContext db)
        {
            _db = db;
        }

        public string GetContent(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return string.Empty;
            var item = _db.Contents.FirstOrDefault(c => c.Slug.ToLower() == slug.ToLower());
            return item?.BodyHtml ?? string.Empty;
        }

        public ContentItem? GetById(int id)
        {
            return _db.Contents.Find(id);
        }

        public IEnumerable<ContentItem> GetAll()
        {
            return _db.Contents.OrderBy(c => c.Id).ToList();
        }

        public void UpdateContent(int id, string bodyHtml)
        {
            var item = _db.Contents.Find(id);
            if (item == null) return;
            item.BodyHtml = bodyHtml;
            item.UpdatedAt = DateTime.UtcNow;
            _db.SaveChanges();
        }
    }
}
