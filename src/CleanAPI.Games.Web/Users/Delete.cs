using Ardalis.Result;
using CleanAPI.Games.UseCases.Users.Delete;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// Delete a User.
/// </summary>
/// <remarks>
/// Delete a User by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteUserRequest>
{
  public override void Configure()
  {
    Delete(DeleteUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteUserRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteUserCommand(request.UserId);

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
