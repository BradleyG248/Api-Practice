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
      db = _db;
    }
    internal IEnumerable<Poll> GetAllPolls()
    {
      string sql = "SELECT * FROM polls";
      return _db.Query<Poll>(sql);
    }
  }
}