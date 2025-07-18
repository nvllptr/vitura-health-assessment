using AutoMapper;
using Vitura.API.DataTransferObjects.PatientDtos;
using Vitura.API.Models;

namespace Vitura.API.AutoMapper.Profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, GetPatientDtoShort>();
        CreateMap<GetPatientDtoShort, Patient>();
        CreateMap<Patient, GetPatientDtoLong>();
    }
}