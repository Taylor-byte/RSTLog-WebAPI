using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    //DTOs which are mapped to the domain models using automapper
    public class CreateTransTypeDTO
    {


        [Required]
        public string Trans_Type { get; set; }
    }

    public class UpdateTransTypeDTO : CreateTransTypeDTO
    {

    }

    public class TransTypeDTO : CreateTransTypeDTO
    {
        public int Id { get; set; }
    }
}
