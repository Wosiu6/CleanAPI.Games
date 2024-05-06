using Ardalis.SharedKernel;

namespace CleanAPI.Games.Core.UserAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a User is deleted.
/// The DeleteUserService is used to dispatch this event.
/// </summary>
internal sealed class UserDeletedEvent(int UserId) : DomainEventBase
{
  public int UserId { get; init; } = UserId;
}
