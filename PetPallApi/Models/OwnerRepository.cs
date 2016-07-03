using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public class OwnerRepository : IOwnerRepository
    {
        PetPallApiContext Context { get; set; }
        public OwnerRepository()
        {
            this.Context = new PetPallApiContext();
        }

        public PetOwner GetPetOwner(int id)
        {
            return Context.PetOwners.Find(id);
        }
    }
}