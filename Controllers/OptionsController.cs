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
  public class OptionsController : ControllerBase
  {
    private readonly OptionsService _ps;
    public OptionsController(OptionsService ps)
    {
      _ps = ps;
    }

    [HttpGet("{PollId}")]
    public ActionResult<IEnumerable<Option>> GetOptionsByPoll(int PollId)
    {
      try
      {
        return Ok(_ps.GetOptionsByPoll(PollId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{Id}")]
    public ActionResult<Option> GetOptionById(int Id)
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
    public ActionResult<Option> CreateOption([FromBody] Option newOption)
    {
      try
      {
        return Ok(_ps.CreateOption(newOption));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{Id}")]
    public ActionResult<Option> EditOption(int Id, [FromBody] Option editedOption)
    {
      try
      {
        editedOption.Id = Id;
        return Ok(_ps.EditOption(editedOption));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{Id}")]
    public ActionResult<String> DeleteOption(int Id)
    {
      try
      {
        return _ps.DeleteOption(Id);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
