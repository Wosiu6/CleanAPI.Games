using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Games.Delete;

public record DeleteGameCommand(int GameId) : ICommand<Result>;
