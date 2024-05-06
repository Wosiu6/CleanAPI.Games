using CleanAPI.Games.Core.GameAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAPI.Games.Infrastructure.Data.Config;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
  public void Configure(EntityTypeBuilder<Game> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.OwnsOne(builder => builder.AchievementsMetaData, ownedNavigationBuilder =>
    {
      ownedNavigationBuilder.ToJson();
      ownedNavigationBuilder.OwnsMany(metaData => metaData.Achievements);
    });

    builder.Property(x => x.Status)
      .HasConversion(
          x => x.Value,
          x => GameStatus.FromValue(x));
  }
}
