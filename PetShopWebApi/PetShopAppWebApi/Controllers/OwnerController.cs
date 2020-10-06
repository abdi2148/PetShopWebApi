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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 0");
            //return _ownerService.FindOwnerById(id);
            return _ownerService.GetOwnerByIdIncludePets(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("First Name missing!");
            }
            if (string.IsNullOrEmpty(owner.SecondName))
            {
                return BadRequest("Second Name missing!");
            }
            if (string.IsNullOrEmpty(owner.Address))
            {
                return BadRequest("Address missing!");
            }
            if (owner.Age <= 0 || owner.Age.Equals(null))
            {
                return BadRequest("Invalid age input!");
            }
            if (owner.PhoneNumber <= 0 || owner.PhoneNumber.Equals(null))
            {
                return BadRequest("Invalid phone input!");
            }
            _ownerService.Create(owner);
            return StatusCode(500, "Owner created successfully!");
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if(owner.Id != id || id < 0)
            {
                return BadRequest("Try another ID");
            }
            _ownerService.Update(owner);
            return StatusCode(500, "Owner updated successfully!");
        }

        // DELETE api/< OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner>Delete(int id)
        {
            return _ownerService.Delete(id);
        }
    }
}
