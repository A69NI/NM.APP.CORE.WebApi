using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_ITProjekt_MainTree_TypController : Controller
    {
        private readonly TBL_AN_ITProjekt_MainTree_TypService _tBL_AN_ITProjekt_MainTree_TypService;

        public TBL_AN_ITProjekt_MainTree_TypController(TBL_AN_ITProjekt_MainTree_TypService tBL_AN_ITProjekt_MainTree_TypService)
        {
            _tBL_AN_ITProjekt_MainTree_TypService = tBL_AN_ITProjekt_MainTree_TypService;

        }

        /// <summary>
        /// Retrieves all IT project main tree type entities.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all IT project
        /// main tree type entities.</returns>
        [HttpGet]
        public async Task<IEnumerable<TBL_AN_ITProjekt_MainTree_Typ>> Get()
        {
            return await _tBL_AN_ITProjekt_MainTree_TypService.GetAllAsync();
        }

        /// <summary>
        /// Retrieves the resource with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the resource to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the resource if found; otherwise, a NotFound result.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tBL_AN_ITProjekt_MainTree_TypService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a new IT project main tree type and returns a response with the created resource.
        /// </summary>
        /// <param name="tBL_AN_ITProjekt_MainTree_Typ">The IT project main tree type entity to create. Must not be null.</param>
        /// <returns>A 201 Created response containing the newly created IT project main tree type and a location header with a
        /// link to the resource.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(TBL_AN_ITProjekt_MainTree_Typ tBL_AN_ITProjekt_MainTree_Typ)
        {
            await _tBL_AN_ITProjekt_MainTree_TypService.AddAsync(tBL_AN_ITProjekt_MainTree_Typ);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_ITProjekt_MainTree_Typ.ITProjekt_MainTreeTyp_ID }, tBL_AN_ITProjekt_MainTree_Typ);
        }

        /// <summary>
        /// Updates an existing IT project main tree type entity with the specified values.
        /// </summary>
        /// <param name="tBL_AN_ITProjekt_MainTree_Typ">The updated entity data for the IT project main tree type. The entity's identifier must correspond to an
        /// existing record.</param>
        /// <returns>A 201 Created response containing the updated entity if the update is successful; otherwise, a 404 Not Found
        /// response if the entity does not exist.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TBL_AN_ITProjekt_MainTree_Typ tBL_AN_ITProjekt_MainTree_Typ)
        {
            var existingEntity = await _tBL_AN_ITProjekt_MainTree_TypService.GetByIdAsync(tBL_AN_ITProjekt_MainTree_Typ.ITProjekt_MainTreeTyp_ID);
            if (existingEntity == null)
            {
                return NotFound();
            }
            await _tBL_AN_ITProjekt_MainTree_TypService.UpdateAsync(tBL_AN_ITProjekt_MainTree_Typ);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_ITProjekt_MainTree_Typ.ITProjekt_MainTreeTyp_ID }, tBL_AN_ITProjekt_MainTree_Typ);
        }

        /// <summary>
        /// Deletes the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="NotFoundResult"/> if the entity does not exist; otherwise, returns <see cref="OkObjectResult"/> with
        /// the deleted entity.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEntity = await _tBL_AN_ITProjekt_MainTree_TypService.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            await _tBL_AN_ITProjekt_MainTree_TypService.DeleteAsync(id);
            return Ok(existingEntity);
        }
    }
}
