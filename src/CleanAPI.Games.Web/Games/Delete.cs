using Ardalis.Result;
using CleanAPI.Games.UseCases.Games.Delete;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// Delete a Game.
/// </summary>
/// <remarks>
/// Delete a Game by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteGameRequest>
{
  public override void Configure()
  {
    Delete(DeleteGameRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteGameRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteGameCommand(request.GameId);

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
