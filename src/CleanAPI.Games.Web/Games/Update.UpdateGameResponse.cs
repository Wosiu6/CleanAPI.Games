namespace CleanAPI.Games.Web.Games;

public class UpdateGameResponse(GameRecord Game)
{
  public GameRecord Game { get; set; } = Game;
}
