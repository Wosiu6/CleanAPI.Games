using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Games.Update;

public record UpdateGameCommand(int GameId, string NewName) : ICommand<Result<GameDTO>>;
