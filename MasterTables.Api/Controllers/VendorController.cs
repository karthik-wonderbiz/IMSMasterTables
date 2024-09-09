using MasterTables.Application.Interfaces;
using MasterTables.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasterTables.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _VendorService;

        public VendorsController(IVendorService VendorService)
        {
            _VendorService = VendorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            try
            {
                var Vendors = await _VendorService.GetAllVendorsAsync();
                return Ok(Vendors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetVendorById(Guid id)
        {
            var Vendor = await _VendorService.GetVendorByIdAsync(id);
            if (Vendor == null)
                return NotFound();
            return Ok(Vendor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor([FromBody] Vendor Vendor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVendor = await _VendorService.CreateVendorAsync(Vendor);
            return CreatedAtAction(nameof(GetVendorById), new { id = createdVendor.Id }, createdVendor);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateVendor(Guid id, [FromBody] Vendor Vendor)
        {
            if (id != Vendor.Id)
                return BadRequest("Vendor ID mismatch.");

            var updatedVendor = await _VendorService.UpdateVendorAsync(Vendor);
            return Ok(updatedVendor);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVendor(Guid id)
        {
            await _VendorService.DeleteVendorAsync(id);
            return NoContent();
        }
    }
}
