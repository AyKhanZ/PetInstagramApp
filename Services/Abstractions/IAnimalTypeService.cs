using PetInstagramAPI.Contracts.Commands.AnimalType;
using PetInstagramAPI.Contracts.Requests.AnimalType;
using PetInstagramAPI.Data.Models;

namespace PetInstagramAPI.Services.Abstractions;

public interface IAnimalTypeService
{
    Task<List<AnimalTypeModel>> GetAnimalTypesAsync(GetAnimalTypeRequest request);
    Task CreateAnimalType(CreateAnimalTypeCommand command);
    Task UpdateAnimalType(Guid id, UpdateAnimalTypeCommand command);
    Task DeleteAnimalType(Guid id);
}
