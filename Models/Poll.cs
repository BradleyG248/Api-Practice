using System;
using System.Collections.Generic;

namespace apiPractice.Models
{
  public class Poll
  {
    public string Name { get; set; }
    public List<string> Questions { get; set; }
  }
}
