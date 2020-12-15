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
    [HttpGet("{Id}")]
    public ActionResult<Poll> GetPollById(int Id)
    {
      try
      {
        return _ps.GetById(Id);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Poll> CreatePoll([FromBody] Poll newPoll)
    {
      try
      {
        return Ok(_ps.CreatePoll(newPoll));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{Id}")]
    public ActionResult<Poll> EditPoll(int Id, [FromBody] Poll editedPoll)
    {
      try
      {
        editedPoll.Id = Id;
        return Ok(_ps.EditPoll(editedPoll));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{Id}")]
    public ActionResult<String> DeletePoll(int Id)
    {
      try
      {
        return _ps.DeletePoll(Id);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
