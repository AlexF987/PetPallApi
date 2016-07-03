using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public class PetRepository : IPetRepository
    {
        PetPallApiContext Context { get; set; }
        public PetRepository()
        {
            this.Context = new PetPallApiContext();
        }

        public IQueryable<Pet> GetPets()
        {
            return Context.Pets.Include(x => x.PetOwner);
        }

        public Pet GetPet(int id)
        {
            return Context.Pets.Find(id);
        }

        public IQueryable<Pet> GetPetsByAge(DateTime DOB)
        {
            return Context.Pets.Where(x => x.DateOfBirth > DOB);
        }

        public void PostPet(Pet pet)
        {
            Context.Pets.Add(pet);
            Context.SaveChanges();
        }

        public void PutPet(int id, Pet pet)
        {
            Context.Entry(pet).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IQueryable<Pet> GetPetsByOwner(int ownerid)
        {
            return Context.Pets.Where(x => x.PetOwnerId == ownerid);
        }
    }
}