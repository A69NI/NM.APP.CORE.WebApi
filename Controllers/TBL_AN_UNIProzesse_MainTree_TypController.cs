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

        [HttpGet]
        public async Task<IEnumerable<TBL_AN_UNIProzesse_MainTree_Typ>> Get()
        {
            return await _tBL_AN_UNIProzesse_MainTree_TypService.GetAllAsync();

        }

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

        [HttpPost]
        public async Task<IActionResult> CreateSensor(TBL_AN_UNIProzesse_MainTree_Typ tBL_AN_UNIProzesse_MainTree_Typ)
        {
            await _tBL_AN_UNIProzesse_MainTree_TypService.AddAsync(tBL_AN_UNIProzesse_MainTree_Typ);
            //var createdSensor = await _sensorService.CreateSensorAsync(sensor);
            return CreatedAtAction(nameof(GetById), new { id = tBL_AN_UNIProzesse_MainTree_Typ.UNIProzessMainTreeTyp_ID  }, tBL_AN_UNIProzesse_MainTree_Typ);
        }


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
