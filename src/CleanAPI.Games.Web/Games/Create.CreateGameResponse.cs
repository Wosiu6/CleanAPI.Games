namespace CleanAPI.Games.Web.Games;

public class CreateGameResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
