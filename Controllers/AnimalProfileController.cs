using Microsoft.AspNetCore.Mvc;
using PetInstagramAPI.Contracts.Commands.AnimalProfile;
using PetInstagramAPI.Contracts.Requests.AnimalProfile;
using PetInstagramAPI.Data.Models;
using PetInstagramAPI.Services.Abstractions;

namespace PetInstagramAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalProfileController : ControllerBase
{
    private readonly IAnimalProfileService _animalProfileService;
    public AnimalProfileController(IAnimalProfileService animalProfileService)
    {
        _animalProfileService = animalProfileService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AnimalProfileModel>>> IndexAsync([FromQuery] GetAnimalProfilesRequest request)
    {
        var result = await _animalProfileService.GetAnimalProfilesAsync(request);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AnimalProfileModel>> GetAnimalProfileAsync([FromQuery] GetAnimalProfileRequest request)
    {
        var result = await _animalProfileService.GetAnimalProfileAsync(request);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<AnimalProfileModel>>> CreateAnimalProfileAsync([FromBody] CreateAnimalProfileCommand command)
    {
        await _animalProfileService.CreateAnimalProfileAsync(command);

        return Ok("Successfully created");
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<List<AnimalProfileModel>>> UpdateAnimalProfileAsync(Guid id, [FromBody] UpdateAnimalProfileCommand command)
    {
        await _animalProfileService.UpdateAnimalProfileAsync(id, command);

        return Ok("Successfully updated");
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<List<AnimalProfileModel>>> DeleteAnimalProfileAsync(Guid id)
    {
        await _animalProfileService.DeleteAnimalProfileAsync(id);

        return Ok("Successfully deleted");
    }
}
