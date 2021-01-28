using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Auth.dto
{
    public class register_request
    {
        public class RegisterRequest
        {
            public string Code { get; set; }

            public string Name { get; set; }

            public DateTime DateUpdated { get; set; }

            public DateTime DateCreated { get; set; }

            public string Avatar { get; set; }

            public string Email { get; set; }

            public string DateOfBirth { get; set; }

            public string Phone { get; set; }

            public string Address { get; set; }

            public string Password { get; set; }
        }
    }
}
