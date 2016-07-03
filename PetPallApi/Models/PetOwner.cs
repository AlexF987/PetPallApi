using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.WebApi;
using FluentValidation.Attributes;
using PetPallApi.Validation;

namespace PetPallApi.Models
{
    [Validator(typeof(PetOwnerValidator))]
    public class PetOwner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<PetWalker> PetWalkers { get; set; }
    }
}