namespace Vitura.API.DataTransferObjects.PatientDtos;

public class GetPatientDtoShort
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}