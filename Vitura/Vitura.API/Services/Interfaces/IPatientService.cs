using Vitura.API.DataTransferObjects.PatientDtos;

namespace Vitura.API.Services.Interfaces;

public interface IPatientService
{
    public List<GetPatientDtoShort> GetAll();
}