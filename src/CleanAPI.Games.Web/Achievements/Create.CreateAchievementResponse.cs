﻿namespace CleanAPI.Games.Web.Achievements;

public class CreateAchievementResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
