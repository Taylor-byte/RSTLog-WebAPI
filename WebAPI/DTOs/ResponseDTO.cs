using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ResponseDTO
    {

        public bool IsSuccessfulRegistration { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
