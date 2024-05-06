using Ardalis.Specification;

namespace CleanAPI.Games.Core.UserAggregate.Specifications;

public class UserByIdSpec : Specification<User>
{
  public UserByIdSpec(int UserId)
  {
    Query
        .Where(User => User.Id == UserId);
  }
}
