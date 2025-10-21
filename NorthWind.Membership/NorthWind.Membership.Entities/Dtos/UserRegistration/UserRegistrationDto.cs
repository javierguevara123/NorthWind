﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Membership.Entities.Dtos.UserRegistration
{
    public class UserRegistrationDto(string email, string password,
 string firstName, string lastName)
    {
        public string Email => email;
        public string Password => password;
        public string FirstName => firstName;
        public string LastName => lastName;
    }

}
