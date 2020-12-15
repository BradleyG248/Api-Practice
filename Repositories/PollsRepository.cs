using Dapper;
using System;
using System.Data;
using apiPractice.Models;
using System.Collections.Generic;

namespace apiPractice.Repositories
{
  public class PollsRepository
  {
    private readonly IDbConnection _db;
    public PollsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Poll> GetAllPolls()
    {
      string sql = "SELECT * FROM polls";
      return _db.Query<Poll>(sql);
    }
    internal Poll GetById(int Id)
    {
      string sql = "SELECT * FROM polls WHERE (id = @Id);";
      Poll poll = _db.QueryFirstOrDefault<Poll>(sql, new { Id });
      if (poll != null)
      {
        return poll;
      }
      throw new Exception("Poll not found");
    }
    internal Poll CreatePoll(Poll newPoll)
    {
      string sql = @"
            INSERT INTO polls
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      newPoll.Id = _db.ExecuteScalar<int>(sql, newPoll);
      return newPoll;
    }
    internal Poll EditPoll(Poll editedPoll)
    {
      string sql = @"
        UPDATE polls
        SET
            name = @Name
        WHERE (id = @Id) LIMIT 1
        ";
      _db.Execute(sql, editedPoll);
      return editedPoll;
    }
    internal string DeletePoll(int Id)
    {
      string sql = "DELETE FROM polls WHERE (id = @Id) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      if (removed == 1)
      {
        return "Deleted";
      }
      throw new Exception("Poll doesn't exist");
    }
  }
}