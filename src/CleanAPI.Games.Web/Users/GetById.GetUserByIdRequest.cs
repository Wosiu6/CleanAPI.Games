namespace CleanAPI.Games.Web.Users;

public class GetUserByIdRequest
{
  public const string Route = "/Users/{UserId:int}";
  public static string BuildRoute(int UserId) => Route.Replace("{UserId:int}", UserId.ToString());

  public int UserId { get; set; }
}
