using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.Core.UserAggregate.Events;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.Services;

/// <summary>
/// This is here mainly so there's an example of a domain service
/// and also to demonstrate how to fire domain events from a service.
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class DeleteUserService(IRepository<User> _repository,
  IMediator _mediator,
  ILogger<DeleteUserService> _logger) : IDeleteUserService
{
  public async Task<Result> DeleteUser(int UserId)
  {
    _logger.LogInformation("Deleting User {UserId}", UserId);
    User? aggregateToDelete = await _repository.GetByIdAsync(UserId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new UserDeletedEvent(UserId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
