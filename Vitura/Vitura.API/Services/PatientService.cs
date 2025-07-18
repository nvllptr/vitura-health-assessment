using AutoMapper;
using Vitura.API.DataTransferObjects.PatientDtos;
using Vitura.API.DataTransferObjects.PrescriptionDtos;
using Vitura.API.Repositories.Interfaces;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Services;

public class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _patientRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PatientService(IPatientRepository patientRepository, IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _prescriptionRepository = prescriptionRepository;
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
        
        var prescriptions = _prescriptionRepository.GetAll(prescription => prescription.PatientId == id);
        
        if(prescriptions == null) return null;
        
        var prescriptionsDto = _mapper.Map<List<GetPrescriptionDto>>(prescriptions);
        patientDto.Prescriptions = prescriptionsDto;

        return patientDto;
    }

}