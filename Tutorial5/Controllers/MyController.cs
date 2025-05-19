using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Services;


namespace Tutorial5.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IDbService _dbService;
        public MyController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpPost]
        [Route("prescription")]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionInsertDTO dto)
        {
            var res = await _dbService.AddPrescriptionAsync(dto);
            if (res)
            {
                return Ok("Prescription added successfully");
            }
            return BadRequest("Failed to add prescription");
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var patientDetails = await _dbService.GetPatientDetailsAsync(id);

            if (patientDetails == null)
                return NotFound($"Patient with ID {id} not found.");

            return Ok(patientDetails);
        }
        
        
        
       
    }
}
