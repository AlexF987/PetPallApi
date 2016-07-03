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

namespace PetPallApi.Controllers
{
    public class PetWalkersController : ApiController
    {

        private IOwnerRepository OwnerRepository;

        public PetWalkersController(IOwnerRepository OwnerRepository)
        {
            this.OwnerRepository = OwnerRepository;
        }

        public IHttpActionResult GetApproval(int id, int ownerid)
        {
            PetOwner PetOwner = OwnerRepository.GetPetOwner(ownerid);
            if (PetOwner.PetWalkers != null && PetOwner.PetWalkers.Any(x => x.Id == id))
                return Ok(true);
            else
                return Ok(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}