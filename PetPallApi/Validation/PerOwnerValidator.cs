using FluentValidation;
using PetPallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPallApi.Validation
{
    public class PetOwnerValidator : AbstractValidator<PetOwner>
    {
        public PetOwnerValidator()
        {
            RuleFor(petowner => petowner.FirstName).NotEmpty();
            RuleFor(petowner => petowner.LastName).NotEmpty();
            RuleFor(petowner => petowner.Email).EmailAddress().NotEmpty();
        }
    }
}