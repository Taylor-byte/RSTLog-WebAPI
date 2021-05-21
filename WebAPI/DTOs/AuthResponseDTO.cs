using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class AuthResponseDTO
    {
        //DTOs which are mapped to the domain models using automapper
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }

    }
}
