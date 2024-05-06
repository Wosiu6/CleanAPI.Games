namespace CleanAPI.Games.Web.Contributors;

public class UpdateContributorResponse(GameRecord contributor)
{
  public GameRecord Contributor { get; set; } = contributor;
}
