using System.Text.Json.Serialization;

namespace Vitura.API.Models;

public class Prescription : BaseModel
{
    [JsonPropertyName("patientId")] 
    public int PatientId { get; set; }

    [JsonPropertyName("drugName")] 
    public string DrugName { get; set; }

    [JsonPropertyName("dosage")] 
    public string Dosage { get; set; }

    [JsonPropertyName("datePrescribed")] 
    public DateOnly DatePrescribed { get; set; }
}