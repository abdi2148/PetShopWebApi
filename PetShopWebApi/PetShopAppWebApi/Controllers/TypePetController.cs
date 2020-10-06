using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePetController : ControllerBase
    {
        private readonly ITypePetService _typePetService;

        public TypePetController(ITypePetService typePetService)
        {
            _typePetService = typePetService;
        }


        // GET: api/<TypePetController>
        [HttpGet]
        public ActionResult<IEnumerable<TypePet>> Get()
        {
            return _typePetService.getAllTypePets();
        }

        // GET api/<TypePetController>/5
        [HttpGet("{id}")]
        public ActionResult<TypePet> Get(int id)
        {
            return _typePetService.getTypeById(id);
        }

        // POST api/<TypePetController>
        [HttpPost]
        public ActionResult<TypePet> Post([FromBody] TypePet typePet)
        {
            if (string.IsNullOrEmpty(typePet.Type))
            {
                BadRequest("invalid input");
            }
            _typePetService.Create(typePet);
            return StatusCode(500, "typePet created successfully.");
        }

        // PUT api/<TypePetController>/5
        [HttpPut("{id}")]
        public ActionResult<TypePet> Put(int id, [FromBody] TypePet typePet)
        {
            if(id<0 || typePet.Id != id)
            {
                return BadRequest("invalid ID input");
            }
            _typePetService.Update(typePet);
            return StatusCode(500, "Update successful");
        }

        // DELETE api/<TypePetController>/5
        [HttpDelete("{id}")]
        public ActionResult<TypePet>Delete(int id)
        {
            return _typePetService.Delete(id);
        }
    }
}
