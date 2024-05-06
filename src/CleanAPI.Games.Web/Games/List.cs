using Ardalis.Result;
using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Games.List;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// List all Games
/// </summary>
/// <remarks>
/// List all Games - returns a GameListResponse containing the Games.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<GameListResponse>
{
  public override void Configure()
  {
    Get("/Games");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<GameDTO>> result = await _mediator.Send(new ListGamesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new GameListResponse
      {
        Games = result.Value.Select(c => new GameRecord(c.Id, c.Name, c.SteamUrl)).ToList()
      };
    }
  }
}
