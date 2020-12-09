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
  }
}