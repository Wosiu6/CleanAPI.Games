namespace CleanAPI.Games.Web.Users;

public class UpdateUserResponse(UserRecord User)
{
  public UserRecord User { get; set; } = User;
}
