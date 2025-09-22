using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PetInstagramAPI.Contracts.Requests.AnimalProfile;

public class GetAnimalProfilesRequest : BaseRequest
{
    [Required]
    public Guid AnimalTypeId { get; set; }
}
