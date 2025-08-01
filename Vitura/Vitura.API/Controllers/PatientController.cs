using Microsoft.AspNetCore.Mvc;
using Vitura.API.DataTransferObjects.PatientDtos;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    
    [HttpGet]
    public ActionResult<List<GetPatientDtoShort>> GetAll()
    {
        var patients = _patientService.GetAll();
        return Ok(patients);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<GetPatientDtoLong> GetById(int id)
    {
        var patient = _patientService.GetById(id);
        if (patient == null) return BadRequest();

        return Ok(patient);
    }
}