using ChargeShare.ChargerService.DAL.DTOs;
using ChargeShare.ChargerService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChargeShare.ChargerService.Controllers
{
    [Route("api/chargers")]
    [ApiController]
    public class ChargerController : ControllerBase
    {
        private readonly IChargerService _chargerService;
        private readonly UserManager<ChargeSharedUserModel> _manager;

        private IEnumerable<IdentityError> _errors { get; set; }

        public ChargerController(IChargerService chargerService, UserManager<ChargeSharedUserModel> manager)
        {
            _chargerService = chargerService;
            _manager = manager;
        }

        // GET: api/<Chargers>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Chargers>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Chargers>
        // Endpoint to create new chargers
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChargerDTO charger)
        {
            if (ModelState.IsValid)
            {
                //handel new charger
                try
                {
                    ChargeSharedUserModel user = await _manager.GetUserAsync(User);
                    return Ok(await _chargerService.RegisterCharger(charger, user));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                foreach (var error in _errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest("Could not save charging station!");
            }
            
        }

        // PUT api/<Chargers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Chargers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
