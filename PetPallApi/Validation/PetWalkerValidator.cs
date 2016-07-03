using FluentValidation;
using PetPallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Validation
{
    public class PetWalkerValidator : AbstractValidator<PetWalker>
    {
        public PetWalkerValidator()
        {
            RuleFor(petwalker => petwalker.FirstName).NotEmpty();
            RuleFor(petwalker => petwalker.LastName).NotEmpty();
            RuleFor(petwalker => petwalker.PhoneNumber).NotEmpty();
        }
    }
}