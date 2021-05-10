﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Your Password is limited to {2} to {1}  characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ICollection<string> Roles { get; set; }

    }
}
