using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    public class PetPallApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PetPallApiContext() : base("name=PetPallApiContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<PetPallApi.Models.PetOwner> PetOwners { get; set; }

        public System.Data.Entity.DbSet<PetPallApi.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<PetPallApi.Models.PetWalker> PetWalkers { get; set; }
    }
}
