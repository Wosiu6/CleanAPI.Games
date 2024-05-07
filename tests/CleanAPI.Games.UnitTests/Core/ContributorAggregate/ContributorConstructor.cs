using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.UserAggregate;
using Xunit;

namespace CleanAPI.Games.UnitTests.Core.ContributorAggregate;

public class ContributorConstructor
{
  private readonly string _testName = "test name";
  private User? _testContributor;

  private User CreateContributor()
  {
    return new User(_testName);
  }

  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }
}
