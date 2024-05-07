using Ardalis.Result;
using CleanAPI.Games.Core.AchievementAggregate;
using CleanAPI.Games.UseCases.Achievements.Get;
using CleanAPI.Games.UseCases.Games.Get;
using CleanAPI.Games.Web.Games;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// Get a Achievement by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Achievement record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetAchievementByIdRequest, AchievementRecord>
{
  public override void Configure()
  {
    Get(GetAchievementByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetAchievementByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetAchievementQuery(request.AchievementId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new AchievementRecord(result.Value.Id, result.Value.Name, result.Value.Description, result.Value.GlobalPercentage);
    }
  }
}
