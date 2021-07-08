using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_back.Models;
using react_back.Services;

namespace react_back.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PostsController : ControllerBase
  {
    private readonly PostsService _ps;
    private readonly CommentsService _cs;

    public PostsController(PostsService ps, CommentsService cs)
    {
      _ps = ps;
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
      try
      {
        return Ok(_ps.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
      try
      {
        return Ok(_ps.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Post>> Post([FromBody] Post newPost)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newPost.CreatorId = userInfo.Id;
        Post post = _ps.Create(newPost);
        post.Creator = userInfo;
        return Ok(post);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Post>> Edit(int id, [FromBody] Post newPost)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newPost.Id = id;
        newPost.CreatorId = userInfo.Id;
        newPost.Creator = userInfo;
        return Ok(_ps.Edit(newPost, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/comments")]
    public ActionResult<IEnumerable<Comment>> GetComments(int id)
    {
      try
      {
        return Ok(_cs.GetByPost(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}