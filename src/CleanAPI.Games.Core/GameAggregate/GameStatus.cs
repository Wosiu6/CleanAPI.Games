using Ardalis.SmartEnum;
using CleanAPI.Games.Core.UserAggregate;

namespace CleanAPI.Games.Core.GameAggregate;

public class GameStatus : SmartEnum<GameStatus>
{
  public static readonly GameStatus New = new(nameof(New), 1);
  public static readonly GameStatus Started = new(nameof(Started), 2);
  public static readonly GameStatus Finished = new(nameof(Finished), 3);

  protected GameStatus(string name, int value) : base(name, value) { }
}

