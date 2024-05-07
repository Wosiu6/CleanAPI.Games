using Ardalis.Result;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games.Create;

/// <summary>
/// Create a new Game.
/// </summary>
/// <param name="Name"></param>
public record CreateGameCommand(string Name, string? SteamUrl) : Ardalis.SharedKernel.ICommand<Result<int>>;
