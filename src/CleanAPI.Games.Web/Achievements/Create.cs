using CleanAPI.Games.Core.AchievementAggregate;
using CleanAPI.Games.UseCases.Achievements.Create;
using CleanAPI.Games.Web.Games;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// Create a new Achievement
/// </summary>
/// <remarks>
/// Creates a new Achievement given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateAchievementRequest, CreateAchievementResponse>
{
  public override void Configure()
  {
    Post(CreateAchievementRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Achievement.";
      //s.Description = "Create a new Achievement. A valid name is required.";
      s.ExampleRequest = new CreateAchievementRequest { Name = "Achievement Name", Description = "www.example.com", GlobalPercentage = 3.5 };
    });
  }

  public override async Task HandleAsync(
    CreateAchievementRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateAchievementCommand(request.Name!,
      request.Description!, (double)request.GlobalPercentage), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateAchievementResponse(result.Value, request.Name!);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
