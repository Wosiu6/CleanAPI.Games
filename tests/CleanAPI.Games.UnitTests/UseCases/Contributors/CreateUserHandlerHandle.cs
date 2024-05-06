using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.UseCases.Users.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CleanAPI.Games.UnitTests.UseCases.Users;

public class CreateUserHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly IRepository<User> _repository = Substitute.For<IRepository<User>>();
  private CreateUserHandler _handler;

  public CreateUserHandlerHandle()
  {
    _handler = new CreateUserHandler(_repository);
  }

  private User CreateUser()
  {
    return new User(_testName);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    _repository.AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateUser()));
    var result = await _handler.Handle(new CreateUserCommand(_testName, null), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
