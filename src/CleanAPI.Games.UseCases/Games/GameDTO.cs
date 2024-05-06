namespace CleanAPI.Games.UseCases.Games;
public record GameDTO(int Id, string Name, string? SteamUrl, List<AchievementDTO> Achievements);

public record AchievementDTO(int Id, string Name, string? Description, double? GlobalPercentage);
