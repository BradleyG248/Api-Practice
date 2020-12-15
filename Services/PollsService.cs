using System;
using System.Collections.Generic;
using apiPractice.Models;
using apiPractice.Repositories;

namespace apiPractice.Services
{
  public class PollsService
  {
    private readonly PollsRepository _repo;
    public PollsService(PollsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Poll> GetAllPolls()
    {
      return _repo.GetAllPolls();
    }
    public Poll CreatePoll(Poll newPoll)
    {
      return _repo.CreatePoll(newPoll);
    }
    public Poll GetById(int Id)
    {
      return _repo.GetById(Id);
    }
    public Poll EditPoll(Poll editedPoll)
    {
      Poll original = GetById(editedPoll.Id);
      original.Name = editedPoll.Name != null ? editedPoll.Name : original.Name;
      return _repo.EditPoll(editedPoll);
    }
    public String DeletePoll(int Id)
    {
      return _repo.DeletePoll(Id);
    }
  }
}