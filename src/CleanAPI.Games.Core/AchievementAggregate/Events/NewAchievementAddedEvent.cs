using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Core.AchievementAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a game is deleted.
/// The DeleteGameService is used to dispatch this event.
/// </summary>
internal sealed class NewAchievementAddedEvent(Game game, Achievement achievement) : DomainEventBase
{
  public Game Game { get; init; } = game;
  public Achievement Achievement { get; init; } = achievement;
}
