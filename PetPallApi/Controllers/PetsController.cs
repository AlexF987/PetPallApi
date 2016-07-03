using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PetPallApi.Models;
using PetPallApi.Validation;

namespace PetPallApi.Controllers
{
    public class PetsController : ApiController
    {
        private IPetRepository PetRepository;

        private IOwnerRepository OwnerRepository;

        private PetValidator Validator;

        public PetsController(IPetRepository PetRepository, IOwnerRepository OwnerRepository)
        {
            this.PetRepository = PetRepository;
            this.OwnerRepository = OwnerRepository;
            Validator = new PetValidator();
        }

        // GET: api/Pets
        public IQueryable<Pet> GetPets()
        {
            return PetRepository.GetPets();
        }

        public IQueryable<Pet> GetPetsByAge(int age)
        {
            DateTime DOB = DateTime.Now.AddYears(age * (-1));
            return PetRepository.GetPetsByAge(DOB);
        }

        public IQueryable<Pet> GetPetsByOwner(int ownerid)
        {
            return PetRepository.GetPetsByOwner(ownerid);
        }

        // GET: api/Pets/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult GetPet(int id)
        {
            Pet pet = PetRepository.GetPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // PUT: api/Pets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.Id)
            {
                return BadRequest();
            }

            PetOwner PetOwner = OwnerRepository.GetPetOwner(pet.PetOwnerId);
            pet.PetOwner = PetOwner;

            try
            {
                PetRepository.PutPet(id, pet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pets
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid || !Validator.Validate(pet).IsValid)
            {
                return BadRequest(ModelState);
            }

            PetOwner PetOwner = OwnerRepository.GetPetOwner(pet.PetOwnerId);

            pet.PetOwner = PetOwner;

            PetRepository.PostPet(pet);

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return PetRepository.GetPets().Count(e => e.Id == id) > 0;
        }
    }
}