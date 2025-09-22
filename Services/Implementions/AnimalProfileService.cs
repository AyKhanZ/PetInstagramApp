using Microsoft.EntityFrameworkCore;
using PetInstagramAPI.Contracts.Commands.AnimalProfile;
using PetInstagramAPI.Contracts.Requests.AnimalProfile;
using PetInstagramAPI.Data.Contexts;
using PetInstagramAPI.Data.Entities;
using PetInstagramAPI.Data.Enums;
using PetInstagramAPI.Data.Models;
using PetInstagramAPI.Services.Abstractions;

namespace PetInstagramAPI.Services.Implementions;

public class AnimalProfileService : IAnimalProfileService
{
    private readonly PetsDbContext _context;

    public AnimalProfileService(PetsDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalProfileModel> GetAnimalProfileAsync(GetAnimalProfileRequest request)
    {
        var profile = await _context.AnimalProfiles.FindAsync(request.Id);

        var animalPhotos = await _context.AnimalPhotos.Where(ap => ap.AnimalProfileId == request.Id).ToListAsync();

        var resultPhotos = new List<AnimalPhotoModel>();
        animalPhotos.ForEach(ap => resultPhotos.Add(new AnimalPhotoModel()
        {
            Id = ap.Id,
            Path = ap.ImagePath,
            LikesCount = ap.LikesCount
        }));

        var resultProfile = new AnimalProfileModel()
        {
            Id = profile.Id,
            Name = profile.Name,
            Age = profile.Age,
            Description = profile.Description,
            AvatarPath = profile.AvatarPath,
            Breed = profile.Breed,
            FollowersCount = profile.FollowersCount,
            AnimalPhotoModels = animalPhotos == null ? [] : resultPhotos
        };

        return resultProfile;
    }

    public async Task<List<AnimalProfileModel>> GetAnimalProfilesAsync(GetAnimalProfilesRequest request)
    {
        var profiles = await _context.AnimalProfiles
            .Where(at => at.AnimalTypeId == request.AnimalTypeId)
            .ToListAsync();

        var resultProfiles = profiles.Select(p => new AnimalProfileModel()
        {
            Id = p.Id,
            Name = p.Name,
            Age = p.Age,
            Description = p.Description,
            AvatarPath = p.AvatarPath,
            Breed = p.Breed,
            FollowersCount = p.FollowersCount
        }).ToList();

        return resultProfiles;
    }

    public Task CreateAnimalProfileAsync(CreateAnimalProfileCommand command)
    {
        var newProfile = new AnimalProfile()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Age = command.Age,
            Gender = command.Gender,
            Description = command.Description,
            AvatarPath = command.AvatarPath,
            Breed = command.Breed,
            AnimalTypeId = command.AnimalTypeId,
        };
        _context.AnimalProfiles.AddAsync(newProfile);
        _context.SaveChangesAsync();

        return Task.WhenAll();
    }

    public Task UpdateAnimalProfileAsync(Guid id, UpdateAnimalProfileCommand command)
    {
        _context.AnimalProfiles.Where(p => p.Id == id).ExecuteUpdateAsync(p => p
            .SetProperty(p => p.Name, command.Name)
            .SetProperty(p => p.Age, command.Age)
            .SetProperty(p => p.Breed, command.Breed)
            .SetProperty(p => p.Gender, command.Gender)
            .SetProperty(p => p.Description, command.Description)
            .SetProperty(p => p.AvatarPath, command.AvatarPath)
            .SetProperty(p => p.AnimalTypeId, command.AnimalTypeId)
            );

        return Task.CompletedTask;
    }

    public Task DeleteAnimalProfileAsync(Guid id)
    {
        _context.AnimalProfiles.Where(p => p.Id == id).ExecuteDeleteAsync();

        return Task.CompletedTask;
    }
}
