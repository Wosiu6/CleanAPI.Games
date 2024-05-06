using Ardalis.Result;

namespace CleanAPI.Games.Core.Interfaces;

public interface IDeleteUserService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteUser(int UserId);
}
