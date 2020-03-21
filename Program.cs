using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CustomClassLinqExcept
{
  class Program
  {
    static void Main(string[] args)
    {
      Test1();
    }

    static void Test1()
    {
      var original = new List<User>()
    {
        new User{ Id = "A01", Name = "Jeffrey" },
        new User{ Id = "A02", Name = "Darkthread" }
    };

      var merged = new List<User>();
      merged.AddRange(original);
      merged.Add(new User
      {
        Id = "B01",
        Name = "Ironman"
      });


      var diff = merged.Except(original);
      Console.WriteLine(JsonConvert.SerializeObject(diff));
    }
  }
}
