using System;
using System.Collections.Generic;

namespace apiPractice.Models
{
  public class Question
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public int Id { get; set; }
    public int PollId { get; set; }
  }
}
