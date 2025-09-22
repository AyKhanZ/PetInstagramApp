namespace PetInstagramAPI.Data.Entities;

public class AnimalPhoto
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; } = "defaultImg.png";
    public uint LikesCount { get; set; }

    public Guid AnimalProfileId { get; set; }
    public AnimalProfile AnimalProfile { get; set; }
}
