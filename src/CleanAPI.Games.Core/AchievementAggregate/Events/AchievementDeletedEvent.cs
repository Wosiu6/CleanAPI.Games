using Ardalis.SharedKernel;

namespace CleanAPI.Games.Core.AchievementAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a game is deleted.
/// The DeleteGameService is used to dispatch this event.
/// </summary>
internal sealed class AchievementDeletedEvent(int achievementId) : DomainEventBase
{
  public int AchievementId { get; init; } = achievementId;
}
