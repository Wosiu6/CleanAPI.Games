using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games;

public static class GameExtensions
{
  public static GameDTO AsDto(this Game game)
  {
    var achievements = game.AchievementsMetaData?.Achievements?.Select(achievement => achievement.AsDto()) ?? [];
    return new GameDTO(game.Id, game.Name, game.SteamUrl, achievements.ToList());
  }

  public static List<GameDTO> AsDtos(this List<Game> games)
  {
    return games.Select(game => game.AsDto()).ToList();
  }

  public static Game AsEntity(this GameDTO game)
  {
    var result = new Game(game.Name, game.SteamUrl);

    result.SetAchievements(game.Achievements.AsEntities());

    return result;
  }

  public static List<Game> AsEntities(this List<GameDTO> games)
  {
    return games.Select(game => game.AsEntity()).ToList();
  }
}

public static class AchievementExtensions
{
  public static AchievementDTO AsDto(this Achievement achievement)
  {
    return new AchievementDTO(achievement.Id, achievement.Name, achievement.Description, achievement.GlobalPercentage);
  }

  public static List<AchievementDTO> AsDtos(this List<Achievement> achievements)
  {
    return achievements.Select(achievement => achievement.AsDto()).ToList();
  }

  public static Achievement AsEntity(this AchievementDTO achievement)
  {
    return new Achievement(achievement.Name, achievement.Description ?? "", achievement.GlobalPercentage);
  }

  public static List<Achievement> AsEntities(this List<AchievementDTO> achievements)
  {
    return achievements.Select(achievement => achievement.AsEntity()).ToList();
  }
}
