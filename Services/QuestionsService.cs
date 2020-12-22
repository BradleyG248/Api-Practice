using System;
using System.Collections.Generic;
using apiPractice.Models;
using apiPractice.Repositories;

namespace apiPractice.Services
{
  public class QuestionsService
  {
    private readonly QuestionsRepository _repo;
    public QuestionsService(QuestionsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Question> GetQuestionsByPoll(int Id)
    {
      return _repo.GetQuestionsByPollId(Id);
    }
    public Question CreateQuestion(Question newQuestion)
    {
      return _repo.CreateQuestion(newQuestion);
    }
    public Question GetById(int Id)
    {
      return _repo.GetById(Id);
    }
    public Question EditQuestion(Question editedQuestion)
    {
      Question original = GetById(editedQuestion.Id);
      original.Name = editedQuestion.Name != null ? editedQuestion.Name : original.Name;
      return _repo.EditQuestion(editedQuestion);
    }
    public String DeleteQuestion(int Id)
    {
      return _repo.DeleteQuestion(Id);
    }
  }
}