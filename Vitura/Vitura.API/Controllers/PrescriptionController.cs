using Microsoft.AspNetCore.Mvc;
using Vitura.API.DataTransferObjects.PrescriptionDtos;
using Vitura.API.Services.Interfaces;

namespace Vitura.API.Controllers;


[Route("api/prescriptions")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    
    [HttpGet]
    public ActionResult<List<GetPrescriptionDto>> GetAll()
    {
        var prescriptions = _prescriptionService.GetAll();
        if(prescriptions == null) return NotFound();
        return Ok(prescriptions);
    }
    
    [HttpPost]
    public ActionResult<GetPrescriptionDto> Create(CreatePrescriptionDto prescription)
    {
        var created = _prescriptionService.Create(prescription);

        if (created == null) return BadRequest();

        return Ok(created);
    }
}