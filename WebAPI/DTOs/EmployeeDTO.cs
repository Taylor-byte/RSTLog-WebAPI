using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateEmployeeDTO
    {
        

        [Required]
        public string Name { get; set; }
    }

    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int Id { get; set; }
    }
}
