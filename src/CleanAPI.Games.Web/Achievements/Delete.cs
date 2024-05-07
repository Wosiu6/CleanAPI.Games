using Ardalis.Result;
using CleanAPI.Games.UseCases.Achievements.Delete;
using CleanAPI.Games.Web.Achievements;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// Delete a Achievement.
/// </summary>
/// <remarks>
/// Delete a Achievement by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteAchievementRequest>
{
  public override void Configure()
  {
    Delete(DeleteAchievementRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteAchievementRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteAchievementCommand(request.AchievementId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
