using PetInstagramAPI.Data.Enums;

namespace PetInstagramAPI.Data.Models;

public class AnimalProfileModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Breed { get; set; }
    public ushort Age { get; set; }
    public string Description { get; set; }
    public string AvatarPath { get; set; }
    public uint FollowersCount { get; set; }
    public List<AnimalPhotoModel> AnimalPhotoModels { get; set; }
}
