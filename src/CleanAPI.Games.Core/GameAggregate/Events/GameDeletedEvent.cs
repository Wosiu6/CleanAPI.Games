using Ardalis.SharedKernel;

namespace CleanAPI.Games.Core.GameAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class GameDeletedEvent(int gameId) : DomainEventBase
{
  public int GameId { get; init; } = gameId;
}
