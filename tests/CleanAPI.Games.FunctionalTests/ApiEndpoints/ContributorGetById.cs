using Ardalis.HttpClientTestExtensions;
using CleanAPI.Games.Infrastructure.Data;
using CleanAPI.Games.Web.Users;
using Xunit;

namespace CleanAPI.Games.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class UserGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedUserGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<UserRecord>(GetUserByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.User1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetUserByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
