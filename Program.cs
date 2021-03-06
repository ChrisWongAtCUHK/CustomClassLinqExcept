﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CustomClassLinqExcept
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\n\n==========IEquatable<T> implementation==========");
      Test2();
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
  }
}
