namespace PetInstagramAPI.Data.Models;

public class AnimalPhotoModel
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    public uint LikesCount { get; set; }
}
