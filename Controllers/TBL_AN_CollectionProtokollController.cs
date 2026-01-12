using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_CollectionProtokollController : Controller
    {
        private readonly TBL_AN_CollectionProtokollService _tBL_AN_CollectionProtokollService;
        public TBL_AN_CollectionProtokollController(TBL_AN_CollectionProtokollService tBL_AN_CollectionProtokollService)
        {
            _tBL_AN_CollectionProtokollService = tBL_AN_CollectionProtokollService;
        }

        /// <summary>
        /// Retrieves all main process records.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all main tree
        /// process entities.</returns>
        [HttpGet]
        public async Task<IEnumerable<TBL_AN_CollectionProtokoll>> Get()
        {
            return await _tBL_AN_CollectionProtokollService.GetAllAsync();

        }

        /// <summary>
        /// Retrieves the main entity with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the sensor entity if found; otherwise, a NotFound result.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _tBL_AN_CollectionProtokollService.GetByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        /// <summary>
        /// Creates a new main entity and adds it to the data store.
        /// </summary>
        /// <param name="tBL_AN_CollectionProtokoll">The sensor entity to create. Must not be null.</param>
        /// <returns>A response with status code 201 (Created) containing the created sensor entity and a location header with a
        /// link to the newly created resource.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSensor(TBL_AN_CollectionProtokoll tBL_AN_CollectionProtokoll)
        {
            await _tBL_AN_CollectionProtokollService.AddAsync(tBL_AN_CollectionProtokoll);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_CollectionProtokoll.Protokoll_ID}, tBL_AN_CollectionProtokoll);
        }


        /// <summary>
        /// Updates the details of an existing main with the specified identifier.
        /// </summary>
        /// <remarks>This method returns a 201 Created response with the updated sensor data if the update
        /// is successful. If the id does not match the MainTree_ID of the provided object, a 400 Bad Request response
        /// is returned. The sensor must already exist; otherwise, the update may not be applied.</remarks>
        /// <param name="id">The unique identifier of the sensor to update. Must match the MainTree_ID property of the provided sensor
        /// object.</param>
        /// <param name="tBL_AN_CollectionProtokoll">An object containing the updated sensor data. The MainTree_ID property must match the value of the id
        /// parameter.</param>
        /// <returns>A CreatedAtActionResult containing the updated sensor if the update is successful; otherwise, a
        /// BadRequestResult if the id does not match the sensor's MainTree_ID.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(int id, TBL_AN_CollectionProtokoll tBL_AN_CollectionProtokoll)
        {
            if (id != tBL_AN_CollectionProtokoll.Protokoll_ID)
            {
                return BadRequest();
            }
            await _tBL_AN_CollectionProtokollService.UpdateAsync(tBL_AN_CollectionProtokoll);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_CollectionProtokoll.Protokoll_ID }, tBL_AN_CollectionProtokoll);
            //if (updatedSensor == null)
            //{
            //    return NotFound();
            //}
            //return Ok(updatedSensor);
        }

        /// <summary>
        /// Deletes the main with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to delete.</param>
        /// <returns>An <see cref="OkObjectResult"/> containing the deleted sensor if the operation is successful; otherwise, a
        /// <see cref="NotFoundResult"/> if no sensor with the specified identifier exists.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            //await _sensorService.DeleteSensorAsync(id);
            //return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
            var deleted = await _tBL_AN_CollectionProtokollService.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
