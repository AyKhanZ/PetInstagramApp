using PetInstagramAPI.Data.Enums;

namespace PetInstagramAPI.Contracts.Commands.AnimalProfile;

public class CreateAnimalProfileCommand
{
    public string Name { get; set; }
    public ushort Age { get; set; }
    public Gender Gender { get; set; }
    public string Breed { get; set; }
    public string? AvatarPath { get; set; }
    public string Description { get; set; }
    public Guid AnimalTypeId { get; set; }
}
