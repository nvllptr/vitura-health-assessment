using Vitura.API.DataTransferObjects.PrescriptionDtos;

namespace Vitura.API.Services.Interfaces;

public interface IPrescriptionService
{
    public List<GetPrescriptionDto>? GetAll();
    
    public List<GetPrescriptionDto>? GetByPatientId(int patientId);

}