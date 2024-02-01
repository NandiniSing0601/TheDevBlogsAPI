using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheDevBlogsAPI.Data;
using TheDevBlogsAPI.Models.Entities;

namespace TheDevBlogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly TheDevBlogsDBcontext _context;
        public PostsController(TheDevBlogsDBcontext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("get-all-blogs")]
        public IActionResult GetAllBlogPosts()
        {
            var posts = _context.Posts.ToList();
            return Ok(posts);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetBlogPostById([FromRoute] Guid id) 
        {  
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
    }
}
