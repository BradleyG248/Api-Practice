using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using apiPractice.Models;
using apiPractice.Services;

namespace apiPractice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PollsController : ControllerBase
  {
    private readonly PollsService _ps;
    public PollsController(PollsService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Poll>> GetAllPolls()
    {
      try
      {
        return Ok(_ps.GetAllPolls());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
