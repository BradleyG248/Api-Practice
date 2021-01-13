using Dapper;
using System;
using System.Data;
using apiPractice.Models;
using System.Collections.Generic;

namespace apiPractice.Repositories
{
  public class OptionsRepository
  {
    private readonly IDbConnection _db;
    public OptionsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Option> GetOptionsByPollId(int Id)
    {
      string sql = "SELECT * FROM options WHERE (pollId = @Id);";
      return _db.Query<Option>(sql);
    }
    internal Option GetById(int Id)
    {
      string sql = "SELECT * FROM options WHERE (id = @Id);";
      Option option = _db.QueryFirstOrDefault<Option>(sql, new { Id });
      if (option != null)
      {
        return option;
      }
      throw new Exception("Option not found");
    }
    internal Option CreateOption(Option newOption)
    {
      string sql = @"
            INSERT INTO options
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      newOption.Id = _db.ExecuteScalar<int>(sql, newOption);
      return newOption;
    }
    internal Option EditOption(Option editedOption)
    {
      string sql = @"
        UPDATE options
        SET
            name = @Name
        WHERE (id = @Id) LIMIT 1
        ";
      _db.Execute(sql, editedOption);
      return editedOption;
    }
    internal string DeleteOption(int Id)
    {
      string sql = "DELETE FROM options WHERE (id = @Id) LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      if (removed == 1)
      {
        return "Deleted";
      }
      throw new Exception("Option doesn't exist");
    }
  }
}