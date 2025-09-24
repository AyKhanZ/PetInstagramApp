using Microsoft.EntityFrameworkCore;
using PetInstagramAPI.Contracts.Commands.AnimalType;
using PetInstagramAPI.Contracts.Requests.AnimalType;
using PetInstagramAPI.Data.Contexts;
using PetInstagramAPI.Data.Entities;
using PetInstagramAPI.Data.Models;
using PetInstagramAPI.Services.Abstractions;

namespace PetInstagramAPI.Services.Implementions;

public class AnimalTypeService : IAnimalTypeService
{
    private readonly PetsDbContext _context;

    public AnimalTypeService(PetsDbContext context)
    {
        _context = context;
    }

    public async Task<List<AnimalTypeModel>> GetAnimalTypesAsync(GetAnimalTypeRequest request)
    {
        var animalTypes = await _context.AnimalTypes.AsNoTracking().ToListAsync();

        var animalTypesResult = new List<AnimalTypeModel>();
        animalTypes.ForEach(at => animalTypesResult.Add(new AnimalTypeModel()
        {
            Id = at.Id,
            Title = at.Title,
            ImagePath = at.ImagePath
        }));

        return animalTypesResult;
    }

    public Task CreateAnimalType(CreateAnimalTypeCommand command)
    {
        var newAnimalType = new AnimalType()
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            ImagePath = command.ImagePath
        };
        _context.AnimalTypes.AddAsync(newAnimalType);
        _context.SaveChangesAsync();

        return Task.CompletedTask;
    }

    //public Task UpdateAnimalType(Guid id, UpdateAnimalTypeCommand command)
    //{
    //    _context.AnimalTypes
    //        .Where(at => at.Id == id)
    //        .ExecuteUpdateAsync(at => at
    //            .SetProperty(a => a.Title, command.Title)
    //            .SetProperty(a => a.ImagePath, command.ImagePath));

    //    return Task.CompletedTask;
    //}

    public Task UpdateAnimalType(Guid id, UpdateAnimalTypeCommand command)
    {
        var entity = _context.AnimalTypes.FindAsync(id);
        if (entity == null) throw;
        
        entity.Title = command.Title;
        entity.ImagePath = command.ImagePath;
        _context.SaveChangesAsync();
        
        return Task.CompletedTask;
    }

    //public Task DeleteAnimalType(Guid id)
    //{
    //    _context.AnimalTypes
    //        .Where(at => at.Id == id)
    //        .ExecuteDeleteAsync();
    //    return Task.CompletedTask;
    //}
    
    public Task DeleteAnimalType(Guid id)
    {
        var entity = _context.AnimalTypes.FindAsync(id);
        if (entity == null) throw;
        
        _context.AnimalTypes.Remove(entity);
        _context.SaveChangesAsync();
        
        return Task.CompletedTask;
    }
}
