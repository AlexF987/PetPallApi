using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public class DBContextFactory :IDbContextFactory
    {
        private PetPallApiContext PetPallApiContext;
        public DBContextFactory()
        {
            PetPallApiContext = new PetPallApiContext();
        }
        public PetPallApiContext GetPetPallApiContext()
        {
            return PetPallApiContext;
        }
    }
}