using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Games.List;

public record ListGamesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<GameDTO>>>;
