using FluentValidation.Attributes;
using PetPallApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Models
{
    [Validator(typeof(PetWalkerValidator))]
    public class PetWalker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Pet> Pets { get; set; }
    }
}