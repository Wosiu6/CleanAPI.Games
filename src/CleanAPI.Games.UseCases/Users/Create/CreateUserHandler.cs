using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;

namespace CleanAPI.Games.UseCases.Users.Create;

public class CreateUserHandler(IRepository<User> _repository)
  : ICommandHandler<CreateUserCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateUserCommand request,
    CancellationToken cancellationToken)
  {
    var newUser = new User(request.Name);
    var createdItem = await _repository.AddAsync(newUser, cancellationToken);

    return createdItem.Id;
  }
}
