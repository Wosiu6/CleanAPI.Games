using Ardalis.SmartEnum;

namespace CleanAPI.Games.Core.UserAggregate;

public class UserStatus : SmartEnum<UserStatus>
{
  public static readonly UserStatus New = new(nameof(New), 1);
  public static readonly UserStatus Established = new(nameof(Established), 2);
  public static readonly UserStatus Elite = new(nameof(Elite), 3);

  protected UserStatus(string name, int value) : base(name, value) { }
}

