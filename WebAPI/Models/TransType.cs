using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TransType
    {
        [Key]
        public int Id { get; set; }

        public string Trans_Type { get; set; }

    }
}
