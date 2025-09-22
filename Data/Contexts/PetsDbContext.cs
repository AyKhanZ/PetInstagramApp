using Microsoft.EntityFrameworkCore;
using PetInstagramAPI.Data.Entities;

namespace PetInstagramAPI.Data.Contexts;

public class PetsDbContext : DbContext
{
    public PetsDbContext(DbContextOptions<PetsDbContext> options) : base(options) { }

    public DbSet<AnimalType> AnimalTypes { get; set; }
    public DbSet<AnimalProfile> AnimalProfiles { get; set; }
    public DbSet<AnimalPhoto> AnimalPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AnimalType>(entity =>
        {
            entity.HasKey(at => at.Id);

            entity.Property(at => at.Title)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(at => at.ImagePath)
                .HasMaxLength(100)
                .HasDefaultValue("defaultImg.png");

            entity.HasMany(at => at.AnimalProfiles)
                  .WithOne(aps => aps.AnimalType)
                  .HasForeignKey(aps => aps.AnimalTypeId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<AnimalProfile>(entity =>
        {
            entity.HasKey(ap => ap.Id);

            entity.Property(ap => ap.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(ap => ap.Breed)
                  .HasMaxLength(100);

            entity.Property(ap => ap.AvatarPath)
                  .HasMaxLength(100)
                  .HasDefaultValue("defaultImg.png");

            entity.Property(ap => ap.Description)
                  .HasMaxLength(500);

            entity.Property(ap => ap.Age);

            entity.Property(ap => ap.FollowersCount);

            entity.HasMany(ap => ap.AnimalPhotos)
                  .WithOne(ap => ap.AnimalProfile)
                  .HasForeignKey(ap => ap.AnimalProfileId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ap => ap.AnimalType)
                  .WithMany(ap => ap.AnimalProfiles)
                  .HasForeignKey(at => at.AnimalTypeId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<AnimalPhoto>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.ImagePath)
                .HasMaxLength(100)
                .HasDefaultValue("defaultImg.png");

            entity.Property(a => a.LikesCount);

            entity.HasOne(a => a.AnimalProfile)
                  .WithMany(ap => ap.AnimalPhotos)
                  .HasForeignKey(ap => ap.AnimalProfileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(builder);
    }
}
