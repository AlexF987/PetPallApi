using FluentValidation;
using PetPallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Validation
{
    public class PetValidator :AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(pet => pet.DateOfBirth).GreaterThan(new DateTime(1970, 1, 1)).NotEmpty();
            RuleFor(pet => pet.Name).NotEmpty();
            RuleFor(pet => pet.PetOwnerId).NotEmpty().NotNull();
        }
    }
}