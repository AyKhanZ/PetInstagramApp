namespace PetInstagramAPI.Contracts.Requests;

public class BaseRequest
{
    public string? Sort { get; set; }
    public int Direction { get; set; } = 1; // 1 - ascending, -1 - descending
}
