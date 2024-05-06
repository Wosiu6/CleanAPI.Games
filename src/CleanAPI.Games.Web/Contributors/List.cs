using Ardalis.Result;
using CleanAPI.Games.UseCases.Contributors;
using CleanAPI.Games.UseCases.Contributors.List;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Contributors;

/// <summary>
/// List all Contributors
/// </summary>
/// <remarks>
/// List all contributors - returns a ContributorListResponse containing the Contributors.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<ContributorListResponse>
{
  public override void Configure()
  {
    Get("/Contributors");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<ContributorDTO>> result = await _mediator.Send(new ListContributorsQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new ContributorListResponse
      {
        Contributors = result.Value.Select(c => new GameRecord(c.Id, c.Name, c.PhoneNumber)).ToList()
      };
    }
  }
}
