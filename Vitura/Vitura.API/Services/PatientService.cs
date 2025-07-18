using AutoMapper;
using Vitura.API.DataTransferObjects.PatientDtos;
using Vitura.API.Repositories.Interfaces;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Services;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _patientRepository;
    
    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }
    
    public List<GetPatientDtoShort> GetAll()
    {
        var patients = _patientRepository.GetAll();
        var patientsDto = _mapper.Map<List<GetPatientDtoShort>>(patients);
        return patientsDto;
    }

}