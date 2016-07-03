using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPallApi.Models
{
    public interface IOwnerRepository
    {
        PetOwner GetPetOwner(int id);
    }
}
