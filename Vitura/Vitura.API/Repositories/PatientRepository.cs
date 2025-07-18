using Vitura.API.Models;
using Vitura.API.Repositories.Interfaces;

namespace Vitura.API.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(ILogger<PatientRepository> logger) : base(logger, "patients.json")
    {
    }
}