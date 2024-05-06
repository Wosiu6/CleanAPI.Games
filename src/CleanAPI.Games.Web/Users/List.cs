using Ardalis.Result;
using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Users;
using CleanAPI.Games.UseCases.Users.List;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// List all Users
/// </summary>
/// <remarks>
/// List all Users - returns a UserListResponse containing the Users.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<UserListResponse>
{
  public override void Configure()
  {
    Get("/Users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<UserDTO>> result = await _mediator.Send(new ListUsersQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new UserListResponse
      {
        Users = result.Value.Select(c => new UserRecord(c.Id, c.Name, c.Games.AsEntities())).ToList()
      };
    }
  }
}
