using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPallApi.Models
{
    public interface IPetRepository
    {
        IQueryable<Pet> GetPets();
        Pet GetPet(int id);
        IQueryable<Pet> GetPetsByAge(DateTime DOB);
        void PostPet(Pet pet);
        void PutPet(int id, Pet pet);
        IQueryable<Pet> GetPetsByOwner(int ownerid);
    }
}
