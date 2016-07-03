using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public class OwnerRepository : IOwnerRepository
    {
        PetPallApiContext Context { get; set; }
        IDbContextFactory DbContextFactory;
        public OwnerRepository(IDbContextFactory DbContextFactory)
        {
            this.DbContextFactory = DbContextFactory;
            this.Context = DbContextFactory.GetPetPallApiContext();
        }

        public PetOwner GetPetOwner(int id)
        {
            return Context.PetOwners.Find(id);
        }
    }
}