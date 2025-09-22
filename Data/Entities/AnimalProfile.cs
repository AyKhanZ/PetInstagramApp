using PetInstagramAPI.Data.Enums;

namespace PetInstagramAPI.Data.Entities;

public class AnimalProfile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Breed { get; set; }
    public ushort Age { get; set; }
    public string Description { get; set; }
    public string AvatarPath { get; set; } = "defaultImg.png";

    public uint FollowersCount { get; set; }

    public Guid AnimalTypeId { get; set; }
    public AnimalType AnimalType { get; set; }

    public ICollection<AnimalPhoto> AnimalPhotos { get; set; }
}
