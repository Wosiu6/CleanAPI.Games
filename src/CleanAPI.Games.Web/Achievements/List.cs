using Ardalis.Result;
using CleanAPI.Games.UseCases.Achievements;
using CleanAPI.Games.UseCases.Achievements.List;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// List all Achievements
/// </summary>
/// <remarks>
/// List all Achievements - returns a AchievementListResponse containing the Achievements.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<AchievementListResponse>
{
  public override void Configure()
  {
    Get("/Achievements");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<AchievementDTO>> result = await _mediator.Send(new ListAchievementsQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new AchievementListResponse
      {
        Achievements = result.Value.Select(c => new AchievementRecord(c.Id, c.Name, c.Description, c.GlobalPercentage)).ToList()
      };
    }
  }
}
