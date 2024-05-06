using Ardalis.HttpClientTestExtensions;
using CleanAPI.Games.Infrastructure.Data;
using CleanAPI.Games.Web.Users;
using Xunit;

namespace CleanAPI.Games.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class UserList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoUsers()
  {
    var result = await _client.GetAndDeserializeAsync<UserListResponse>("/Users");

    Assert.Equal(2, result.Users.Count);
    Assert.Contains(result.Users, i => i.Name == SeedData.User1.Name);
    Assert.Contains(result.Users, i => i.Name == SeedData.User2.Name);
  }
}
