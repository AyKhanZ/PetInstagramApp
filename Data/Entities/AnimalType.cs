namespace PetInstagramAPI.Data.Entities;

//Cat / Dog / Hamster / Parrot / Fish
public class AnimalType
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; } = "defaultImg.png";


    public ICollection<AnimalProfile> AnimalProfiles { get; set; }
}
