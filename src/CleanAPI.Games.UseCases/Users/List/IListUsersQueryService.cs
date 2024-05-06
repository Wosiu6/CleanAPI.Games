namespace CleanAPI.Games.UseCases.Users.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListUsersQueryService
{
  Task<IEnumerable<UserDTO>> ListAsync();
}
