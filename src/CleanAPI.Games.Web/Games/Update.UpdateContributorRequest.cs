using System.ComponentModel.DataAnnotations;

namespace CleanAPI.Games.Web.Games;

public class UpdateGameRequest
{
  public const string Route = "/Games/{GameId:int}";
  public static string BuildRoute(int GameId) => Route.Replace("{GameId:int}", GameId.ToString());

  public int GameId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
