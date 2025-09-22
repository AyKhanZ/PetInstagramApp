using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PetInstagramAPI.Contracts.Commands.AnimalType;

public class UpdateAnimalTypeCommand
{
    public string Title { get; set; }
    public string? ImagePath { get; set; }
}
