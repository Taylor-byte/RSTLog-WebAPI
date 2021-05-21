using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class RefreshTokenDTO
    {
        //DTOs which are mapped to the domain models using automapper
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
