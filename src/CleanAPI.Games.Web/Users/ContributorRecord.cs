using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Web.Users;

public record UserRecord(int Id, string Name, List<Game> Games);
