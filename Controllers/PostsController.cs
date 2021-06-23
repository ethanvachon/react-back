using Microsoft.AspNetCore.Mvc;
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
  }
}