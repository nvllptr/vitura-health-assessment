using AutoMapper;
using Vitura.API.DataTransferObjects.PrescriptionDtos;
using Vitura.API.Repositories.Interfaces;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Services;

public class PrescriptionService : IPrescriptionService
{

    private readonly IMapper _mapper;
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    public List<GetPrescriptionDto>? GetAll()
    {
        var prescriptions = _prescriptionRepository.GetAll();

        if (prescriptions == null) return null;

        var prescriptionsDto = _mapper.Map<List<GetPrescriptionDto>>(prescriptions);

        return prescriptionsDto;
    }
    
    public List<GetPrescriptionDto>?  GetByPatientId(int patientId)
    {
        var prescriptions = _prescriptionRepository.GetAll(prescription => prescription.PatientId == patientId);

        if (prescriptions == null) return null;
        
        var prescriptionsDto = _mapper.Map<List<GetPrescriptionDto>>(prescriptions);

        return prescriptionsDto;
    }

}