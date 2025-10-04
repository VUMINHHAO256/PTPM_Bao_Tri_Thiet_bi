using DeviceMaintenance.BLL;
using DeviceMaintenance.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMaintenance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly AssetService _service;

        public AssetsController(AssetService service)
        {
            _service = service;
        }

        // GET api/assets
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var assets = await _service.GetAll();
            return Ok(assets);
        }

        // GET api/assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var asset = await _service.GetById(id);
            if (asset == null) return NotFound();
            return Ok(asset);
        }

        // POST api/assets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Asset asset)
        {
            var created = await _service.Add(asset);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT api/assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Asset asset)
        {
            if (id != asset.Id) return BadRequest();
            await _service.Update(asset);
            return NoContent();
        }

        // DELETE api/assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
