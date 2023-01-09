using ChargeShare.ChargerService.DAL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChargeShare.ChargerService.Controllers
{
    [Route("api/chargers")]
    [ApiController]
    public class ChargerController : ControllerBase
    {

        private IEnumerable<IdentityError> _errors { get; set; }

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
        [HttpPost]
        public void Post([FromBody] ChargerDTO charger)
        {
            if (ModelState.IsValid)
            {
                //handel new charger
            }
            else
            {
                
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
