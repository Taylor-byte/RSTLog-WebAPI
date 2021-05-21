using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ResetPasswordResponseDTO
    {
        //DTOs which are mapped to the domain models using automapper
        public bool IsResetPasswordSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
