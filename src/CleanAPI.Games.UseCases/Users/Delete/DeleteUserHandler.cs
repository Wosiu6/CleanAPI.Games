using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.Interfaces;

namespace CleanAPI.Games.UseCases.Users.Delete;

public class DeleteUserHandler(IDeleteUserService _deleteUserService)
  : ICommandHandler<DeleteUserCommand, Result>
{
  public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _deleteUserService.DeleteUser(request.UserId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.UserId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new UserDeletedEvent(request.UserId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
