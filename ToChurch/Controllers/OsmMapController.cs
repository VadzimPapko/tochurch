using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToChurch.Interfaces;
using ToChurch.Models;

namespace ToChurch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class OsmMapController : ControllerBase
    {
        private readonly IChurchRepository _churchRepository;

        public OsmMapController(IChurchRepository churchRepository)
        {
            _churchRepository = churchRepository;
        }

        // GET: api/OsmMap
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            var result = _churchRepository.GetAddresses();

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        // GET: api/OsmMap/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OsmMap
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OsmMap/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
