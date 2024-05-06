using System.ComponentModel.DataAnnotations;

namespace CleanAPI.Games.Web.Users;

public class UpdateUserRequest
{
  public const string Route = "/Users/{UserId:int}";
  public static string BuildRoute(int UserId) => Route.Replace("{UserId:int}", UserId.ToString());

  public int UserId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
