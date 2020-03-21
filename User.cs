using System;

namespace CustomClassLinqExcept
{
  public class User : IEquatable<User>
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public bool Equals(User other)
    {
      if (other == null) return false;
      return this.Id == other.Id;
    }

    public override bool Equals(object obj) => Equals(obj as User);
    public override int GetHashCode() => Id.GetHashCode();
  }
}
