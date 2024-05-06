using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Games.Get;

public record GetGameQuery(int GameId) : IQuery<Result<GameDTO>>;
