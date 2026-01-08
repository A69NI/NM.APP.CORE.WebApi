using Microsoft.AspNetCore.Mvc;
using NM.CORE.Application.Services;
using NM.CORE.Domain.Entities;

namespace NM.CORE.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TBL_AN_UNIProzess_MainTreeController : ControllerBase
    {
        private readonly TBL_AN_UNIProzess_MainTreeService _tBL_AN_UNIProzess_MainTreeService;
        public TBL_AN_UNIProzess_MainTreeController(TBL_AN_UNIProzess_MainTreeService tBL_AN_UNIProzess_MainTreeService)
        {
            _tBL_AN_UNIProzess_MainTreeService = tBL_AN_UNIProzess_MainTreeService;
        }

        [HttpGet]
        public async Task<IEnumerable<TBL_AN_UNIProzesse_MainTree>> Get()
        {
            return await _tBL_AN_UNIProzess_MainTreeService.GetAllAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _tBL_AN_UNIProzess_MainTreeService.GetByIdAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }
            return Ok(sensor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSensor(TBL_AN_UNIProzesse_MainTree tBL_AN_UNIProzesse_MainTree)
        {
            await _tBL_AN_UNIProzess_MainTreeService.AddAsync(tBL_AN_UNIProzesse_MainTree);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_UNIProzesse_MainTree.MainTree_ID }, tBL_AN_UNIProzesse_MainTree);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensor(int id, TBL_AN_UNIProzesse_MainTree tBL_AN_UNIProzesse_MainTree)
        {
            if (id != tBL_AN_UNIProzesse_MainTree.MainTree_ID)
            {
                return BadRequest();
            }
            await _tBL_AN_UNIProzess_MainTreeService.UpdateAsync(tBL_AN_UNIProzesse_MainTree);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_UNIProzesse_MainTree.MainTree_ID }, tBL_AN_UNIProzesse_MainTree);
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
            var deleted = await _tBL_AN_UNIProzess_MainTreeService.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }

}
