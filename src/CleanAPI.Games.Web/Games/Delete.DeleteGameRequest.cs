namespace CleanAPI.Games.Web.Games;

public record DeleteGameRequest
{
  public const string Route = "/Games/{GameId:int}";
  public static string BuildRoute(int GameId) => Route.Replace("{GameId:int}", GameId.ToString());

  public int GameId { get; set; }
}
