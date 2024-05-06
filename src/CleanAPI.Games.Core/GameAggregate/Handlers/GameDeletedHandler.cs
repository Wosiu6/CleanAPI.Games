using CleanAPI.Games.Core.GameAggregate.Events;
using CleanAPI.Games.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Core.GameAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class GameDeletedHandler(ILogger<GameDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<GameDeletedEvent>
{
  public async Task Handle(GameDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Game Deleted event for {gameId}", domainEvent.GameId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Game Deleted",
                                     $"Game with id {domainEvent.GameId} was deleted.");
  }
}
