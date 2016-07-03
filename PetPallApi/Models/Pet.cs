using FluentValidation.Attributes;
using PetPallApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    [Validator(typeof(PetValidator))]
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int PetOwnerId { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}