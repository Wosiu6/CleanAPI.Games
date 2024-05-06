using System.ComponentModel.DataAnnotations;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Web.Users;

public class CreateUserRequest
{
  public const string Route = "/Users";

  [Required]
  public string? Name { get; set; }
  public List<Game>? Games { get; set; }
}
