using Ardalis.Result;
using CleanAPI.Games.UseCases.Games.Get;
using CleanAPI.Games.UseCases.Games.Update;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// Update an existing Game.
/// </summary>
/// <remarks>
/// Update an existing Game by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateGameRequest, UpdateGameResponse>
{
  public override void Configure()
  {
    Put(UpdateGameRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateGameRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateGameCommand(request.Id, request.Name!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetGameQuery(request.GameId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateGameResponse(new GameRecord(dto.Id, dto.Name, dto.SteamUrl));
      return;
    }
  }
}
