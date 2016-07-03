using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public interface IDbContextFactory
    {
        PetPallApiContext GetPetPallApiContext();
    }
}