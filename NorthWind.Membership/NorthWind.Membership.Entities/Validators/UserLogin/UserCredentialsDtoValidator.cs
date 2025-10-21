﻿using NorthWind.Membership.Entities.Resources;
using NorthWind.Membership.Entities.UserLogin;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Membership.Entities.Validators.UserLogin
{
    internal class UserCredentialsDtoValidator :
 AbstractModelValidator<UserCredentialsDto>
    {
        public UserCredentialsDtoValidator(
       IValidationService<UserCredentialsDto> validationService) :
       base(validationService)
        {
            AddRuleFor(u => u.Email)
            .NotEmpty(UserLoginMessages.RequiredEmailErrorMessage)
            .EmailAddress(UserLoginMessages.InvalidEmailErrorMessage);
            AddRuleFor(u => u.Password)
            .NotEmpty(UserLoginMessages.RequiredPasswordErrorMessage);
        }
    }

}
