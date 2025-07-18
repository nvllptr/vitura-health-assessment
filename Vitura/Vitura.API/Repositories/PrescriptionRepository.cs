using Vitura.API.Models;
using Vitura.API.Repositories.Interfaces;

namespace Vitura.API.Repositories;

public class PrescriptionRepository :  BaseRepository<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(ILogger<PrescriptionRepository> logger) : base(logger, "prescriptions.json")
    {
    }
}