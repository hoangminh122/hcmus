﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Auth.dto
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required !")
              .MinimumLength(6).WithMessage("Password is at least 6 character");

        }
    }
}
