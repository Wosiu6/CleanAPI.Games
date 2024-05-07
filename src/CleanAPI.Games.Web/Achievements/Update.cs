using Ardalis.Result;
using CleanAPI.Games.UseCases.Achievements.Get;
using CleanAPI.Games.UseCases.Achievements.Update;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// Update an existing Achievement.
/// </summary>
/// <remarks>
/// Update an existing Achievement by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateAchievementRequest, UpdateAchievementResponse>
{
  public override void Configure()
  {
    Put(UpdateAchievementRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateAchievementRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateAchievementCommand(request.Id, request.Name!, request.Desciption!, request.GlobalPercentage), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetAchievementQuery(request.AchievementId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateAchievementResponse(new AchievementRecord(dto.Id, dto.Name, dto.Description, dto.GlobalPercentage));
      return;
    }
  }
}
