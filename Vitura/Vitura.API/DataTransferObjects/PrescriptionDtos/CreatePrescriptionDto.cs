namespace Vitura.API.DataTransferObjects.PrescriptionDtos;

public class CreatePrescriptionDto
{
    public int PatientId { get; set; }

    public string DrugName { get; set; }

    public string Dosage { get; set; }

    public DateOnly DatePrescribed { get; set; }
}