using CAB_Pharmacy.Models;
using CAB_Pharmacy.Services;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyManagementSystem.API.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicinesController(IMedicineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            var medicines = await _service.GetMedicinesAsync(search);
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var medicine = await _service.GetMedicineAsync(id);
            return medicine is null ? NotFound() : Ok(medicine);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medicine medicine)
        {
            await _service.AddMedicineAsync(medicine);
            return CreatedAtAction(nameof(Get), new { id = medicine.Id }, medicine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Medicine medicine)
        {
            if (id != medicine.Id) return BadRequest();
            await _service.UpdateMedicineAsync(medicine);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteMedicineAsync(id);
            return NoContent();
        }
    }
}
