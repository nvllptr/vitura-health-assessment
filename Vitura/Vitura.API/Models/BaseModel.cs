using System.Text.Json.Serialization;

namespace Vitura.API.Models;

public class BaseModel
{
    [JsonPropertyName("id")] 
    public int Id { get; set; }
}