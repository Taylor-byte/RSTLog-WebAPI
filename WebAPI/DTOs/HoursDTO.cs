using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateHoursDTO
    {

        public DateTime DateComplete { get; set; }

        public string Comments { get; set; }

        
        public int CustomerId { get; set; }

        
    }

    public class HoursDTO : CreateHoursDTO
    {
        public int Id { get; set; }

        public CustomerDTO Customer { get; set; }
    }
}
