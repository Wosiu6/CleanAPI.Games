using CleanAPI.Games.UseCases.Games;

namespace CleanAPI.Games.UseCases.Users;
public record UserDTO(int Id, string Name, List<GameDTO> Games);
