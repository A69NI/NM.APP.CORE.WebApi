using Microsoft.AspNetCore.Mvc;
using NM.CORE.Application.Services;
using NM.CORE.Domain.Entities;

namespace NM.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly SensorService _sensorService;
        public SensorsController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Sensor>> Get()
        {
            return await _sensorService.GetAllSensorsAsync();
          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorById(int id)
        {
            var sensor = await _sensorService.GetSensorByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSensor(Sensor sensor)
        {
            await _sensorService.AddSensorAsync(sensor);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(int id, Sensor sensor)
        {
            if (id != sensor.ID)
            {
                return BadRequest();
            }
            await _sensorService.UpdateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
            //if (updatedSensor == null)
            //{
            //    return NotFound();
            //}
            //return Ok(updatedSensor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            //await _sensorService.DeleteSensorAsync(id);
            //return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
            var deleted = await _sensorService.DeleteSensorAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
