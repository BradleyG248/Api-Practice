using Dapper;
using System;
using System.Data;
using apiPractice.Models;
using System.Collections.Generic;

namespace apiPractice.Repositories
{
  public class QuestionsRepository
  {
    private readonly IDbConnection _db;
    public QuestionsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Question> GetQuestionsByPollId(int Id)
    {
      string sql = "SELECT * FROM questions WHERE (pollId = @Id);";
      return _db.Query<Question>(sql);
    }
    internal Question GetById(int Id)
    {
      string sql = "SELECT * FROM questions WHERE (id = @Id);";
      Question question = _db.QueryFirstOrDefault<Question>(sql, new { Id });
      if (question != null)
      {
        return question;
      }
      throw new Exception("Question not found");
    }
    internal Question CreateQuestion(Question newQuestion)
    {
      string sql = @"
            INSERT INTO questions
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      newQuestion.Id = _db.ExecuteScalar<int>(sql, newQuestion);
      return newQuestion;
    }
    internal Question EditQuestion(Question editedQuestion)
    {
      string sql = @"
        UPDATE questions
        SET
            name = @Name
        WHERE (id = @Id) LIMIT 1
        ";
      _db.Execute(sql, editedQuestion);
      return editedQuestion;
    }
    internal string DeleteQuestion(int Id)
    {
      string sql = "DELETE FROM questions WHERE (id = @Id) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      if (removed == 1)
      {
        return "Deleted";
      }
      throw new Exception("Question doesn't exist");
    }
  }
}