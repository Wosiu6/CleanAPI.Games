using System.ComponentModel.DataAnnotations;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Web.Games;

public class CreateGameRequest
{
  public const string Route = "/Games";

  [Required]
  public string? Name { get; set; }
  public string? SteamUrl { get; set; }
}
