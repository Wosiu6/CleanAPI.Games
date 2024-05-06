using CleanAPI.Games.UseCases.Users.Create;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// Create a new User
/// </summary>
/// <remarks>
/// Creates a new User given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateUserRequest, CreateUserResponse>
{
  public override void Configure()
  {
    Post(CreateUserRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new User.";
      //s.Description = "Create a new User. A valid name is required.";
      s.ExampleRequest = new CreateUserRequest { Name = "User Name" };
    });
  }

  public override async Task HandleAsync(
    CreateUserRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateUserCommand(request.Name!,
      request.Games), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateUserResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
