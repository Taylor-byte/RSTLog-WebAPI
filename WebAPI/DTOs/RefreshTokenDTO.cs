using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class RefreshTokenDTO
    {

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
