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
  public class QuestionsController : ControllerBase
  {
    private readonly QuestionsService _ps;
    public QuestionsController(QuestionsService ps)
    {
      _ps = ps;
    }

    [HttpGet("{PollId}")]
    public ActionResult<IEnumerable<Question>> GetQuestionsByPoll(int PollId)
    {
      try
      {
        return Ok(_ps.GetQuestionsByPoll(PollId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{Id}")]
    public ActionResult<Question> GetQuestionById(int Id)
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
    public ActionResult<Question> CreateQuestion([FromBody] Question newQuestion)
    {
      try
      {
        return Ok(_ps.CreateQuestion(newQuestion));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{Id}")]
    public ActionResult<Question> EditQuestion(int Id, [FromBody] Question editedQuestion)
    {
      try
      {
        editedQuestion.Id = Id;
        return Ok(_ps.EditQuestion(editedQuestion));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{Id}")]
    public ActionResult<String> DeleteQuestion(int Id)
    {
      try
      {
        return _ps.DeleteQuestion(Id);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
