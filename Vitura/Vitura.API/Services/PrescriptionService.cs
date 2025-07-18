using AutoMapper;
using Vitura.API.DataTransferObjects.PrescriptionDtos;
using Vitura.API.Models;
using Vitura.API.Repositories.Interfaces;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Services;

public class PrescriptionService : IPrescriptionService
{

    private readonly IMapper _mapper;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPatientRepository _patientRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public List<GetPrescriptionDto>? GetAll()
    {
        var prescriptions = _prescriptionRepository.GetAll();

        if (prescriptions == null) return null;

        var prescriptionsDto = _mapper.Map<List<GetPrescriptionDto>>(prescriptions);

        return prescriptionsDto;
    }

    public GetPrescriptionDto? Create(CreatePrescriptionDto createPrescriptionDto)
    {
        var prescription = _mapper.Map<Prescription>(createPrescriptionDto);

        var patient = _patientRepository.GetById(createPrescriptionDto.PatientId);
        
        if(patient == null) return null;
        
        var createdPrescription = _prescriptionRepository.Create(prescription);

        if (createdPrescription == null) return null;

        var prescriptionDto = _mapper.Map<GetPrescriptionDto>(createdPrescription);

        return prescriptionDto;
    }
}