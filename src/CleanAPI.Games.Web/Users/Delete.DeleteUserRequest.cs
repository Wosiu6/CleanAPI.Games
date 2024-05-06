﻿namespace CleanAPI.Games.Web.Users;

public record DeleteUserRequest
{
  public const string Route = "/Users/{UserId:int}";
  public static string BuildRoute(int UserId) => Route.Replace("{UserId:int}", UserId.ToString());
  
  public int UserId { get; set; }
}
