using AutoMapper;
using Vitura.API.DataTransferObjects.PrescriptionDtos;
using Vitura.API.Models;

namespace Vitura.API.AutoMapper.Profiles;

public class PrescriptionProfile : Profile
{
    public PrescriptionProfile()
    {
        CreateMap<Prescription, GetPrescriptionDto>();
        CreateMap<GetPrescriptionDto, Prescription>();
        CreateMap<CreatePrescriptionDto, Prescription>();
    }
}