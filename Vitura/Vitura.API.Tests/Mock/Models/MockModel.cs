using System.Text.Json.Serialization;
using Vitura.API.Models;

namespace Vitura.API.Tests.Mock.Models;

public class MockModel : BaseModel
{
    [JsonPropertyName("name")] 
    public string Name { get; set; }
}