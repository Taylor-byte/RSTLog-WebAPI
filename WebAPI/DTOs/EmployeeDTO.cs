using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    //DTOs which are mapped to the domain models using automapper
    public class CreateEmployeeDTO
    {
        

        [Required]
        public string Name { get; set; }
    }

    public class UpdateEmployeeDTO : CreateEmployeeDTO
    {

    }

    public class EmployeeDTO : CreateEmployeeDTO
    {
        public int Id { get; set; }
    }
}
