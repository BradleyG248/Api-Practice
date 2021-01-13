using System;
using System.Collections.Generic;
using apiPractice.Models;
using apiPractice.Repositories;

namespace apiPractice.Services
{
  public class OptionsService
  {
    private readonly OptionsRepository _repo;
    public OptionsService(OptionsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Option> GetOptionsByPoll(int Id)
    {
      return _repo.GetOptionsByPollId(Id);
    }
    public Option CreateOption(Option newOption)
    {
      return _repo.CreateOption(newOption);
    }
    public Option GetById(int Id)
    {
      return _repo.GetById(Id);
    }
    public Option EditOption(Option editedOption)
    {
      Option original = GetById(editedOption.Id);
      original.Name = editedOption.Name != null ? editedOption.Name : original.Name;
      return _repo.EditOption(editedOption);
    }
    public String DeleteOption(int Id)
    {
      return _repo.DeleteOption(Id);
    }
  }
}