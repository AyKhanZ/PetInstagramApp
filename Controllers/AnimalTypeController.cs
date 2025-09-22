using Microsoft.AspNetCore.Mvc;
using PetInstagramAPI.Contracts.Commands.AnimalType;
using PetInstagramAPI.Contracts.Requests.AnimalType;
using PetInstagramAPI.Data.Models;
using PetInstagramAPI.Services.Abstractions;

namespace PetInstagramAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalTypeController : ControllerBase
{
    private readonly IAnimalTypeService _animalTypeService;
    public AnimalTypeController(IAnimalTypeService animalTypeService)
    {
        _animalTypeService = animalTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AnimalTypeModel>>> Index([FromQuery] GetAnimalTypeRequest request)
    {
        var result = await _animalTypeService.GetAnimalTypesAsync(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<AnimalTypeModel>>> CreateAnimalTypeAsync([FromBody] CreateAnimalTypeCommand command)
    {
        await _animalTypeService.CreateAnimalType(command);
        return Ok("Successfully created!");
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<List<AnimalTypeModel>>> UpdateAnimalTypeAsync(Guid id, [FromBody] UpdateAnimalTypeCommand command)
    {
        await _animalTypeService.UpdateAnimalType(id, command);
        return Ok("Successfully updated!");
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<List<AnimalTypeModel>>> DeleteAnimalTypeAsync(Guid id)
    {
        await _animalTypeService.DeleteAnimalType(id);
        return Ok("Successfully deleted!");
    }
}
