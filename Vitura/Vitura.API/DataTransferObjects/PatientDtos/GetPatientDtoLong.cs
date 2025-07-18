

using Vitura.API.DataTransferObjects.PrescriptionDtos;

namespace Vitura.API.DataTransferObjects.PatientDtos;

public class GetPatientDtoLong : GetPatientDtoShort
{
    public List<GetPrescriptionDto> Prescriptions { get; set; }
}