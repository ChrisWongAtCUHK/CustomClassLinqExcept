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
      Console.WriteLine("\n\n==========Class except==========");
      Test1();
      Console.WriteLine("\n\n==========Different instance==========");
      Test2();
      Console.WriteLine("\n\n==========Custom comparer==========");
      Test3();
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

    static void Test2()
    {
      var original = new List<User>()
      {
          new User{ Id = "A01", Name = "Jeffrey" },
          new User{ Id = "A02", Name = "Darkthread" }
      };
      var originalJson = JsonConvert.SerializeObject(original);

      var merged = new List<User>();
      merged.AddRange(original);
      merged.Add(new User
      {
        Id = "B01",
        Name = "Ironman"
      });
      var mergedJson = JsonConvert.SerializeObject(merged);

      //模擬情境
      //original 由資料庫欄位 JSON 還原
      //merged 由 WebAPI Request 傳入 JSON 還原
      var fromDb = JsonConvert.DeserializeObject<List<User>>(originalJson);
      var fromReq = JsonConvert.DeserializeObject<List<User>>(mergedJson);

      var diff = fromReq.Except(fromDb);
      Console.WriteLine(JsonConvert.SerializeObject(diff, Formatting.Indented));
    }

    static void Test3()
    {
      var original = new List<User>()
        {
            new User{ Id = "A01", Name = "Jeffrey" },
            new User{ Id = "A02", Name = "Darkthread" }
        };
      var originalJson = JsonConvert.SerializeObject(original);

      var merged = new List<User>();
      merged.AddRange(original);
      merged.Add(new User
      {
        Id = "B01",
        Name = "Ironman"
      });
      var mergedJson = JsonConvert.SerializeObject(merged);

      //模擬情境
      //original 由資料庫欄位 JSON 還原
      //merged 由 WebAPI Request 傳入 JSON 還原
      var fromDb = JsonConvert.DeserializeObject<List<User>>(originalJson);
      var fromReq = JsonConvert.DeserializeObject<List<User>>(mergedJson);

      var diff = fromReq.Except(fromDb, new UserComparer());
      Console.WriteLine(JsonConvert.SerializeObject(diff));
    }
  }
}
