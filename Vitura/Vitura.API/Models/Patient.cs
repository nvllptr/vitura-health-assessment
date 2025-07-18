using System.Text.Json.Serialization;

namespace Vitura.API.Models;

public class Patient : BaseModel
{
    [JsonPropertyName("fullName")] 
    public string FullName { get; set; }

    [JsonPropertyName("dateOfBirth")] 
    public DateOnly DateOfBirth { get; set; }
}