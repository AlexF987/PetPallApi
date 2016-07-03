namespace PetPallApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PetPallApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PetPallApi.Models.PetPallApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetPallApi.Models.PetPallApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.PetOwners.AddOrUpdate(x => x.Id,
        new PetOwner() { Id = 1, FirstName = "Jane", LastName = "Austen" },
        new PetOwner() { Id = 2, FirstName = "Charles", LastName = "Dickens" },
        new PetOwner() { Id = 3, FirstName = "Miguel", LastName = "de Cervantes" }
        );

            context.Pets.AddOrUpdate(x => x.Id,
                new Pet()
                {
                    Id = 1,
                    Name = "Pride and Prejudice",
                    DateOfBirth = new DateTime(2011, 1, 1),
                    PetOwnerId = 1
                },
                new Pet()
                {
                    Id = 2,
                    Name = "Northanger Abbey",
                    DateOfBirth = new DateTime(2009, 7, 8),
                    PetOwnerId = 2
                },
                new Pet()
                {
                    Id = 3,
                    Name = "David Copperfield",
                    DateOfBirth = new DateTime(2014, 3, 1),
                    PetOwnerId = 3
                },
                new Pet()
                {
                    Id = 4,
                    Name = "Don Quixote",
                    DateOfBirth = new DateTime(2007, 5, 4),
                    PetOwnerId = 3
                }
                );
        }
    }
}
