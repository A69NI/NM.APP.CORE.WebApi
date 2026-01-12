using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_UNIProzesse_MainTree_TypController : Controller
    {

        private readonly TBL_AN_UNIProzesse_MainTree_TypService _tBL_AN_UNIProzesse_MainTree_TypService;
        public TBL_AN_UNIProzesse_MainTree_TypController(TBL_AN_UNIProzesse_MainTree_TypService tBL_AN_UNIProzesse_MainTree_TypService)
        {
            _tBL_AN_UNIProzesse_MainTree_TypService = tBL_AN_UNIProzesse_MainTree_TypService;
        }

        /// <summary>
        /// Liefert alle Einträge aus der Datensatz Typ Tabelle zurück. Retrieves all TBL_AN_UNIProzesse_MainTree_Typ entities asynchronously.
        /// </summary>
        /// <remarks>This method is typically used to obtain the complete list of
        /// TBL_AN_UNIProzesse_MainTree_Typ records from the underlying data source. The returned collection will be
        /// empty if no entities are found.</remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of
        /// TBL_AN_UNIProzesse_MainTree_Typ entities.</returns>
        [HttpGet]
        public async Task<IEnumerable<TBL_AN_UNIProzesse_MainTree_Typ>> Get()
        {
            return await _tBL_AN_UNIProzesse_MainTree_TypService.GetAllAsync();

        }

        /// <summary>
        /// Liefert ein Eintrag anhand der Key ID inkl. Beziehungen zurück.Retrieves the sensor entity with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to retrieve. Must be a valid, existing sensor ID.</param>
        /// <returns>An <see cref="IActionResult"/> containing the sensor entity if found; otherwise, a NotFound result if no
        /// sensor with the specified ID exists.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _tBL_AN_UNIProzesse_MainTree_TypService.GetByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        /// <summary>
        /// Erstellt einen neuen Eintrag in der Main Tree Typ Tabelle. Creates a new sensor entity using the provided data and returns a response indicating the result of the
        /// operation.
        /// </summary>
        /// <param name="tBL_AN_UNIProzesse_MainTree_Typ">The sensor entity to create. Must contain valid data for all required fields.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the creation operation. Returns a 201 Created
        /// response with the newly created sensor entity and its location.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSensor(TBL_AN_UNIProzesse_MainTree_Typ tBL_AN_UNIProzesse_MainTree_Typ)
        {
            await _tBL_AN_UNIProzesse_MainTree_TypService.AddAsync(tBL_AN_UNIProzesse_MainTree_Typ);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_UNIProzesse_MainTree_Typ.UNIProzessMainTreeTyp_ID  }, tBL_AN_UNIProzesse_MainTree_Typ);
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Eintrag in der Main Tree Typ Tabelle. Updates the sensor entity with the specified identifier using the provided data.
        /// </summary>
        /// <remarks>This method requires that the <paramref name="id"/> parameter matches the
        /// <c>UNIProzessMainTreeTyp_ID</c> property of the provided sensor data. If they do not match, the request is
        /// rejected with a bad request response.</remarks>
        /// <param name="id">The unique identifier of the sensor to update. Must match the identifier in <paramref
        /// name="tBL_AN_UNIProzesse_MainTree_Typ"/>.</param>
        /// <param name="tBL_AN_UNIProzesse_MainTree_Typ">An object containing the updated sensor data. The <c>UNIProzessMainTreeTyp_ID</c> property must match
        /// <paramref name="id"/>.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the update operation. Returns <see
        /// cref="BadRequestResult"/> if the identifiers do not match; otherwise, returns <see
        /// cref="CreatedAtActionResult"/> with the updated sensor data.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(int id, TBL_AN_UNIProzesse_MainTree_Typ tBL_AN_UNIProzesse_MainTree_Typ)
        {
            if (id != tBL_AN_UNIProzesse_MainTree_Typ.UNIProzessMainTreeTyp_ID)
            {
                return BadRequest();
            }
            await _tBL_AN_UNIProzesse_MainTree_TypService.UpdateAsync(tBL_AN_UNIProzesse_MainTree_Typ);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_UNIProzesse_MainTree_Typ.UNIProzessMainTreeTyp_ID }, tBL_AN_UNIProzesse_MainTree_Typ);
            //if (updatedSensor == null)
            //{
            //    return NotFound();
            //}
            //return Ok(updatedSensor);
        }

        /// <summary>
        /// Löscht einen vorhandenen Eintrag anhand der Key ID. Deletes the sensor with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sensor to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="OkObjectResult"/> with the deleted sensor if successful; otherwise, <see cref="NotFoundResult"/> if no
        /// sensor with the specified identifier exists.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            //await _sensorService.DeleteSensorAsync(id);
            //return CreatedAtAction(nameof(GetSensorById), new { id = sensor.ID }, sensor);
            var deleted = await _tBL_AN_UNIProzesse_MainTree_TypService.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
