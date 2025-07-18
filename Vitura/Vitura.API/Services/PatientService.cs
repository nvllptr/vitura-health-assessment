using AutoMapper;
using Vitura.API.DataTransferObjects.PatientDtos;
using Vitura.API.Repositories.Interfaces;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Services;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _patientRepository;
    private readonly IPrescriptionService _prescriptionService;

    public PatientService(IPatientRepository patientRepository, IPrescriptionService prescriptionService, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _prescriptionService = prescriptionService;
        _mapper = mapper;
    }
    
    public List<GetPatientDtoShort> GetAll()
    {
        var patients = _patientRepository.GetAll();
        var patientsDto = _mapper.Map<List<GetPatientDtoShort>>(patients);
        return patientsDto;
    }
    
    public GetPatientDtoLong? GetById(int id)
    {
        var patient = _patientRepository.GetById(id);
        if (patient == null) return null;

        var patientDto = _mapper.Map<GetPatientDtoLong>(patient);
        
        var prescriptionsDto = _prescriptionService.GetByPatientId(patient.Id);
        
        if(prescriptionsDto == null) return null;
        patientDto.Prescriptions = prescriptionsDto;

        return patientDto;
    }

}