using Application.DTO.Request;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("post")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] PostDTO addPostCommand)
        {
            try
            {
                var user = await _postService.Create(addPostCommand);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }            
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _postService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetByText/{text}")]
        [Authorize]
        public async Task<ActionResult> GetByText(string text)
        {
            try
            {
                var post = await _postService.GetByText(text);

                return Ok(post);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetByImage/{image}")]
        [Authorize]
        public async Task<ActionResult> GetByImage(string image)
        {
            try
            {
                var post = await _postService.GetByImage(image);

                return Ok(post);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetByLink/{link}")]
        //[Authorize]
        public async Task<ActionResult> GetByLink(string link)
        {
            try
            {
                var post = await _postService.GetByLink(link);

                return Ok(post);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
