using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ForgotPasswordDTO
    {
        //DTOs which are mapped to the domain models using automapper
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ClientURI { get; set; }
    }
}
