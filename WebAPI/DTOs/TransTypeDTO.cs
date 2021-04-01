using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateTransTypeDTO
    {


        [Required]
        public string Name { get; set; }
    }

    public class UpdateTransTypeDTO : CreateTransTypeDTO
    {

    }

    public class TransTypeDTO : CreateTransTypeDTO
    {
        public int Id { get; set; }
    }
}
