using Microsoft.AspNetCore.Mvc;
using NM.APP.CORE.Application.Services;
using NM.APP.CORE.Domain.Entities;

namespace NM.APP.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_ITProjekt_MainTreeController : ControllerBase
    {
        private readonly TBL_AN_ITProjekt_MainTreeService tBL_AN_ITProjekt_MainTreeService;

        public TBL_AN_ITProjekt_MainTreeController(TBL_AN_ITProjekt_MainTreeService tBL_AN_ITProjekt_MainTreeService)
        {
            this.tBL_AN_ITProjekt_MainTreeService = tBL_AN_ITProjekt_MainTreeService;
        }

        /// <summary>
        /// Retrieves all main tree project records.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the collection of main tree project records.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await tBL_AN_ITProjekt_MainTreeService.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the main tree entity with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the main tree entity to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the main tree entity if found; otherwise, a 404 Not Found
        /// response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await tBL_AN_ITProjekt_MainTreeService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the project tree data associated with the specified type identifier.
        /// </summary>
        /// <param name="typ_id">The unique identifier of the project type to retrieve data for.</param>
        /// <returns>An <see cref="IActionResult"/> containing the project tree data if found; otherwise, a NotFound result.</returns>
        [HttpGet("by-typ/{typ_id}")]
        public async Task<IActionResult> GetByTypId(int typ_id)
        {
            var result = await tBL_AN_ITProjekt_MainTreeService.GetByTypIdAsync(typ_id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a new IT project main tree entry and returns a response with the location of the created resource.
        /// </summary>
        /// <param name="tBL_AN_ITProjekt_MainTree">The IT project main tree entity to create. Must not be null.</param>
        /// <returns>A 201 Created response containing the created IT project main tree entity and a Location header with the URI
        /// of the new resource.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(TBL_AN_ITProjekt_MainTree tBL_AN_ITProjekt_MainTree)
        {
            await tBL_AN_ITProjekt_MainTreeService.AddAsync(tBL_AN_ITProjekt_MainTree);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_ITProjekt_MainTree.MainTree_ID }, tBL_AN_ITProjekt_MainTree);


        }
    }
}
