using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.Entity;
using PetShopApp.Core.Entities;
using PetShopApp.Coree.ApplicationServices.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        // GET: api/<PetController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet>Get(int id)
        {
            return _petService.FindPetById(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("missing Name");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("missing colour");
            }
            if (pet.Price <= 0 || pet.Price.Equals(null))
            {
                return BadRequest("invalid Price input");
            }
            _petService.Create(pet);
            return StatusCode(500, $" Pet {pet.Name} created successfully");
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if(id < 0 || id != pet.Id)
            {
                return BadRequest("invalid ID");
            }
            _petService.Update(pet);
            return StatusCode(500, $"Pet {pet.Name} updated successfully");

        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet>Delete(int id)
        {
            _petService.Delete(id);
            return StatusCode(500, $" Pet ");
        }
    }
}
