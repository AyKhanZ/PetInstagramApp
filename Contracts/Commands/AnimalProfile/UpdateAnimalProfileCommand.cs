using Microsoft.AspNetCore.Mvc;
using PetInstagramAPI.Data.Enums;

namespace PetInstagramAPI.Contracts.Commands.AnimalProfile;

public class UpdateAnimalProfileCommand
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string? AvatarPath { get; set; }
    public string Description { get; set; }
    public Gender Gender { get; set; }
    public Guid AnimalTypeId { get; set; }
}
