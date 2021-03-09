using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateDaysDTO
    {

        public DateTime DateComplete { get; set; }

        public string Comments { get; set; }

        public int CustomerId { get; set; }

    }

    public class DaysDTO : CreateDaysDTO
    {
        public int Id { get; set; }

        public CustomerDTO Customer { get; set; }
    }
}
