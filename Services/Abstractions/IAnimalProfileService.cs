using PetInstagramAPI.Contracts.Commands.AnimalProfile;
using PetInstagramAPI.Contracts.Requests.AnimalProfile;
using PetInstagramAPI.Data.Models;

namespace PetInstagramAPI.Services.Abstractions;

public interface IAnimalProfileService
{
    Task<List<AnimalProfileModel>> GetAnimalProfilesAsync(GetAnimalProfilesRequest request);
    Task<AnimalProfileModel> GetAnimalProfileAsync(GetAnimalProfileRequest request);
    Task CreateAnimalProfileAsync(CreateAnimalProfileCommand command);
    Task UpdateAnimalProfileAsync(Guid id, UpdateAnimalProfileCommand command);
    Task DeleteAnimalProfileAsync(Guid id);
}
