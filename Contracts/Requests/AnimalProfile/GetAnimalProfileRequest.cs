using Microsoft.AspNetCore.Mvc;

namespace PetInstagramAPI.Contracts.Requests.AnimalProfile;

public class GetAnimalProfileRequest
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
