using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.UseCases.Games.Create;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// Create a new Game
/// </summary>
/// <remarks>
/// Creates a new Game given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateGameRequest, CreateGameResponse>
{
  public override void Configure()
  {
    Post(CreateGameRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Game.";
      //s.Description = "Create a new Game. A valid name is required.";
      s.ExampleRequest = new CreateGameRequest { Name = "Game Name", SteamUrl = "www.example.com" };
    });
  }

  public override async Task HandleAsync(
    CreateGameRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateGameCommand(request.Name!,
      request.SteamUrl), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateGameResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
