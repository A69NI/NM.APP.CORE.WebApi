using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers
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

        /// <summary>
        /// Retrieves all sensors from the system.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all sensors. The
        /// collection is empty if no sensors are available.</returns>
        [HttpGet]
        public async Task<IEnumerable<Sensor>> Get()
        {
            return await _sensorService.GetAllSensorsAsync();
          
        }

        /// <summary>
        /// Retrieves the sensor with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to retrieve.</param>
        /// <returns>An <see cref="OkObjectResult"/> containing the sensor if found; otherwise, a <see cref="NotFoundResult"/> if
        /// no sensor exists with the specified identifier.</returns>
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

        /// <summary>
        /// Creates a new sensor and returns a response with the location of the created resource.
        /// </summary>
        /// <remarks>If the sensor is successfully created, the response includes the sensor data and a
        /// Location header pointing to the GetSensorById action for the new sensor.</remarks>
        /// <param name="sensor">The sensor entity to create. Must not be null and should contain valid sensor data.</param>
        /// <returns>A 201 Created response containing the created sensor and a Location header with the URI of the new resource.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSensor(Sensor sensor)
        {
            await _sensorService.AddSensorAsync(sensor);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
        }

        /// <summary>
        /// Updates the details of an existing sensor with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to update. Must match the ID of the provided sensor object.</param>
        /// <param name="sensor">The sensor object containing the updated details. The object's ID must match the value of the <paramref
        /// name="id"/> parameter.</param>
        /// <returns>A <see cref="CreatedAtActionResult"/> containing the updated sensor if the update is successful; otherwise,
        /// a <see cref="BadRequestResult"/> if the IDs do not match.</returns>
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

        /// <summary>
        /// Deletes the sensor with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to delete.</param>
        /// <returns>An <see cref="OkObjectResult"/> containing the deleted sensor if the operation is successful; otherwise, a
        /// <see cref="NotFoundResult"/> if no sensor with the specified identifier exists.</returns>
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
