using Ardalis.Result;
using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Users.Get;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// Get a User by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching User record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetUserByIdRequest, UserRecord>
{
  public override void Configure()
  {
    Get(GetUserByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetUserByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetUserQuery(request.UserId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      List<Game> games = result.Value.Games.Select(gameDto =>
      {
        var result = new Game(gameDto.Name, gameDto.SteamUrl);
        return result;
      }).ToList();

      Response = new UserRecord(result.Value.Id, result.Value.Name);
    }
  }
}
