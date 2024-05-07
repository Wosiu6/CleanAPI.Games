using CleanAPI.Games.Core.AchievementAggregate.Events;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.AchievementAggregate.Handlers;

/// <summary>
/// NOTE: Internal because GameDeleted is also marked as internal.
/// </summary>
internal class AchievementDeletedHandler(ILogger<AchievementDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<AchievementDeletedEvent>
{
  public async Task Handle(AchievementDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Achievement Deleted event for {achievementId}", domainEvent.AchievementId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Achievement Deleted",
                                     $"Achievement with id {domainEvent.AchievementId} was deleted.");
  }
}
