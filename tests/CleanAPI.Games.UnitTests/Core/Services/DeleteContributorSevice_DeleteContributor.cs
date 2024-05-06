using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CleanAPI.Games.UnitTests.Core.Services;

public class DeleteUserService_DeleteUser
{
  private readonly IRepository<User> _repository = Substitute.For<IRepository<User>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteUserService> _logger = Substitute.For<ILogger<DeleteUserService>>();

  private readonly DeleteUserService _service;

  public DeleteUserService_DeleteUser()
  {
    _service = new DeleteUserService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindUser()
  {
    var result = await _service.DeleteUser(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
