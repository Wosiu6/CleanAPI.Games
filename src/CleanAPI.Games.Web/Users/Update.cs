using Ardalis.Result;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Users.Get;
using CleanAPI.Games.UseCases.Users.Update;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// Update an existing User.
/// </summary>
/// <remarks>
/// Update an existing User by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
  public override void Configure()
  {
    Put(UpdateUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateUserRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateUserCommand(request.Id, request.Name!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetUserQuery(request.UserId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateUserResponse(new UserRecord(dto.Id, dto.Name));
      return;
    }
  }
}
