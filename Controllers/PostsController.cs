using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheDevBlogsAPI.Data;
using TheDevBlogsAPI.Models.DTO;
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
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetBlogPostById")]
        public IActionResult GetBlogPostById([FromRoute] Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPost]
        [Route("create-new-blog")]
        public IActionResult Post([FromBody] CreateNewBlogRequestDto blogRequestDto)
        {
            Post post = new Post()
            {
                Title = blogRequestDto.Title,
                Content = blogRequestDto.Content,
                Summary = blogRequestDto.Summary,
                UrlHandle = blogRequestDto.UrlHandle,
                FeaturedImageUrl = blogRequestDto.FeaturedImageUrl,
                Author = blogRequestDto.Author,
                PublishedDate = blogRequestDto.PublishedDate,
                UpdatedDate = blogRequestDto.UpdatedDate,
                Visible = blogRequestDto.Visible,
            };
            _context.Posts.Add(post);
            _context.SaveChanges();

            CreateNewBlogRequestDto postDto = new CreateNewBlogRequestDto()
            {
                Title=post.Title,
                Content=post.Content,
                Summary=post.Summary,
                UrlHandle=post.UrlHandle,
                FeaturedImageUrl=post.FeaturedImageUrl,
                Author = post.Author,
                PublishedDate = post.PublishedDate,
                UpdatedDate = post.UpdatedDate,
                Visible = post.Visible,
            };
            return CreatedAtAction(nameof(GetBlogPostById),new{ id = post.Id } , postDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateBlogPost([FromRoute] Guid id , [FromBody] UpdateBlogRequestDto updateBlog)
        {
             var exixtingPost = _context.Posts.FirstOrDefault(x => x.Id == id);
            if(exixtingPost != null)
            {
                exixtingPost.Title = updateBlog.Title;
                exixtingPost.Content = updateBlog.Content;
                exixtingPost.Summary = updateBlog.Summary;
                exixtingPost.UrlHandle = updateBlog.UrlHandle;
                exixtingPost.FeaturedImageUrl = updateBlog.FeaturedImageUrl;
                exixtingPost.Author = updateBlog.Author;
                exixtingPost.Visible = updateBlog.Visible;
                exixtingPost.PublishedDate = updateBlog.PublishedDate;
                exixtingPost.UpdatedDate = updateBlog.UpdatedDate;
                _context.SaveChanges();
                return Ok("Successfully Updated");
            }
            return BadRequest();

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeletePostById([FromRoute] Guid id)
        {
            var existingPost = _context.Posts.FirstOrDefault(x => x.Id == id);
            if (existingPost != null)
            {
                _context.Posts.Remove(existingPost);
                _context.SaveChanges();
                return Ok("Deleted successfully");
            }
            return BadRequest();
        }

    }
}
