using Microsoft.EntityFrameworkCore;
using TheDevBlogsAPI.Models.Entities;

namespace TheDevBlogsAPI.Data
{
    public class TheDevBlogsDBcontext : DbContext
    {
        public TheDevBlogsDBcontext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }
}
