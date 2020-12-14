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
  }
}