using System;
using System.Collections.Generic;

namespace CustomClassLinqExcept
{
  public class UserComparer : IEqualityComparer<User>
  {
    public bool Equals(User x, User y)
    {
      if (Object.ReferenceEquals(x, y)) return true;
      if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
        return false;
      return x.Id == y.Id;
    }

    public int GetHashCode(User obj)
    {
      if (object.ReferenceEquals(obj, null)) return 0;
      return obj.Id == null ? 0 : obj.Id.GetHashCode();
    }
  }
}
