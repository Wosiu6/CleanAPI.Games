using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate.Events;
using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.Services;

/// <summary>
/// Delete Game domain Service
/// Firing domain events from a service
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class DeleteGameService(IRepository<Game> _repository,
  IMediator _mediator,
  ILogger<DeleteGameService> _logger) : IDeleteGameService
{
  public async Task<Result> DeleteGame(int gameId)
  {
    _logger.LogInformation("Deleting Game {gameId}", gameId);
    Game? aggregateToDelete = await _repository.GetByIdAsync(gameId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new GameDeletedEvent(gameId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
