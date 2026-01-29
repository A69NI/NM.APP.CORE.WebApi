using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_SolutionThemeController : Controller
    {
        private readonly TBL_AN_SolutionThemeService _tBL_AN_SolutionThemeService;
        public TBL_AN_SolutionThemeController(TBL_AN_SolutionThemeService tBL_AN_SolutionThemeService)
        {
            _tBL_AN_SolutionThemeService = tBL_AN_SolutionThemeService;
        }

        /// <summary>
        /// Liefert alle Einträge aus der Protokoll Tabelle zurück. Retrieves all main process records.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all main tree
        /// process entities.</returns>
        [HttpGet]
        public async Task<IEnumerable<TBL_AN_SolutionTheme>> Get()
        {
            return await _tBL_AN_SolutionThemeService.GetAllAsync();

        }

        /// <summary>
        ///  Liefert einen Eintrag anhand der Key ID inkl. Beziehung zurück. Retrieves the main entity with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the sensor entity if found; otherwise, a NotFound result.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _tBL_AN_SolutionThemeService.GetByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        /// <summary>
        /// Erstellt einen neuen Eintrag in der Protokoll Tabelle. Creates a new main entity and adds it to the data store.
        /// </summary>
        /// <param name="tBL_AN_SolutionTheme">The sensor entity to create. Must not be null.</param>
        /// <returns>A response with status code 201 (Created) containing the created sensor entity and a location header with a
        /// link to the newly created resource.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSensor(TBL_AN_SolutionTheme tBL_AN_SolutionTheme)
        {
            await _tBL_AN_SolutionThemeService.AddAsync(tBL_AN_SolutionTheme);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_SolutionTheme.SolutionTheme_ID }, tBL_AN_SolutionTheme);
        }


        /// <summary>
        /// Aktualisiert einen bestehenden Eintrag in der Protokoll Tabelle. Updates the details of an existing main with the specified identifier.
        /// </summary>
        /// <remarks>This method returns a 201 Created response with the updated sensor data if the update
        /// is successful. If the id does not match the MainTree_ID of the provided object, a 400 Bad Request response
        /// is returned. The sensor must already exist; otherwise, the update may not be applied.</remarks>
        /// <param name="id">The unique identifier of the sensor to update. Must match the MainTree_ID property of the provided sensor
        /// object.</param>
        /// <param name="tBL_AN_SolutionTheme">An object containing the updated sensor data. The MainTree_ID property must match the value of the id
        /// parameter.</param>
        /// <returns>A CreatedAtActionResult containing the updated sensor if the update is successful; otherwise, a
        /// BadRequestResult if the id does not match the sensor's MainTree_ID.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(int id, TBL_AN_SolutionTheme tBL_AN_SolutionTheme)
        {
            if (id != tBL_AN_SolutionTheme.SolutionTheme_ID)
            {
                return BadRequest();
            }
            await _tBL_AN_SolutionThemeService.UpdateAsync(tBL_AN_SolutionTheme);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_SolutionTheme.SolutionTheme_ID }, tBL_AN_SolutionTheme);
            //if (updatedSensor == null)
            //{
            //    return NotFound();
            //}
            //return Ok(updatedSensor);
        }

        /// <summary>
        /// Löscht einen vorhandenen Eintrag anhand der Key ID. Deletes the main with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to delete.</param>
        /// <returns>An <see cref="OkObjectResult"/> containing the deleted sensor if the operation is successful; otherwise, a
        /// <see cref="NotFoundResult"/> if no sensor with the specified identifier exists.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            //await _sensorService.DeleteSensorAsync(id);
            //return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
            var deleted = await _tBL_AN_SolutionThemeService.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }


    }
}
