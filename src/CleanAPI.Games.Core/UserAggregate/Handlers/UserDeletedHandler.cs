using CleanAPI.Games.Core.UserAggregate.Events;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.UserAggregate.Handlers;

/// <summary>
/// NOTE: Internal because UserDeleted is also marked as internal.
/// </summary>
internal class UserDeletedHandler(ILogger<UserDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<UserDeletedEvent>
{
  public async Task Handle(UserDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {UserId}", domainEvent.UserId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "User Deleted",
                                     $"User with id {domainEvent.UserId} was deleted.");
  }
}
