using CleanAPI.Games.Core.AchievementAggregate.Events;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.AchievementAggregate.Handlers;

/// <summary>
/// NOTE: Internal because GameDeleted is also marked as internal.
/// </summary>
internal class NewAchievementAddedHandler(ILogger<NewAchievementAddedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<NewAchievementAddedEvent>
{
  public async Task Handle(NewAchievementAddedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Achievement Added event for {achievement.id} and Game {game.id}", domainEvent.Achievement.Id, domainEvent.Game.Id);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Achievement Added",
                                     $"Achievement with id {domainEvent.Achievement.Id} was added.");
  }
}
