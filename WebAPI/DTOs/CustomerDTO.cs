﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateCustomerDTO
    {

        [Required]
        public string Name { get; set; }

        public int? HoursPurchased { get; set; }

        public int? HoursRemaining { get; set; }

        public DateTime Invoiced { get; set; }

        public string Notes { get; set; }

        public int? OnsitePurchased { get; set; }

        public bool Paid { get; set; }

    }

    public class CustomerDTO : CreateCustomerDTO
    {
        public int Id { get; set; }

        public IList<HoursDTO> Hours { get; set; }

        public IList<DaysDTO> Days { get; set; }
    }


}
