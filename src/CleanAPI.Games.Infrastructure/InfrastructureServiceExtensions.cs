using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.Interfaces;
using CleanAPI.Games.Core.Services;
using CleanAPI.Games.Infrastructure.Data;
using CleanAPI.Games.Infrastructure.Data.Queries;
using CleanAPI.Games.Infrastructure.Email;
using CleanAPI.Games.UseCases.Users.List;
using CleanAPI.Games.UseCases.Games.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanAPI.Games.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListUsersQueryService, ListUserQueryService>();
    services.AddScoped<IDeleteUserService, DeleteUserService>();
    services.AddScoped<IListGamesQueryService, ListGamesQueryService>();
    services.AddScoped<IDeleteGameService, DeleteGameService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
