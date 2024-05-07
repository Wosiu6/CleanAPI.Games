using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate.Events;
using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using CleanAPI.Games.Core.AchievementAggregate.Events;
using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.Core.Services;

/// <summary>
/// Delete Achievement domain Service
/// Firing domain events from a service
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class DeleteAchievementService(IRepository<Achievement> _repository,
  IMediator _mediator,
  ILogger<DeleteGameService> _logger) : IDeleteAchievementService
{
  public async Task<Result> DeleteAchievement(int achievementId)
  {
    _logger.LogInformation("Deleting Achievement {achievementId}", achievementId);
    Achievement? aggregateToDelete = await _repository.GetByIdAsync(achievementId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new AchievementDeletedEvent(achievementId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
