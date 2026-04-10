using DeviceManagement.API.Models;
using DeviceManagement.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _repo;

        public DevicesController(IDeviceRepository repo)
        {
            _repo = repo;
        }

        // GET api/devices
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _repo.GetAllAsync();
            return Ok(devices);
        }

        // GET api/devices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var device = await _repo.GetByIdAsync(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        // POST api/devices
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Device device)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _repo.CreateAsync(device);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Device device)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _repo.UpdateAsync(id, device);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}