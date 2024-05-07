using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.UseCases.Games;

namespace CleanAPI.Games.UseCases.Users.Update;

public class UpdateUserHandler(IRepository<User> _repository)
  : ICommandHandler<UpdateUserCommand, Result<UserDTO>>
{
  public async Task<Result<UserDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
  {
    var existingUser = await _repository.GetByIdAsync(request.UserId, cancellationToken);
    if (existingUser == null)
    {
      return Result.NotFound();
    }

    existingUser.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingUser, cancellationToken);

    return Result.Success(new UserDTO(existingUser.Id,
      existingUser.Name, existingUser.Games.Select(GameDTO.FromToDoItem).ToList()));
  }
}
