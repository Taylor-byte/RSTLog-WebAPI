using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateCustomerDTO
    {

        [Required(ErrorMessage = "Name Field is required")]
        public string Name { get; set; }

        public int? HoursPurchased { get; set; }

        public int? HoursRemaining { get; set; }

        public DateTime? Invoiced { get; set; }

        public string Notes { get; set; }

        public int? OnsitePurchased { get; set; }

        public bool Paid { get; set; }

        public string InvoicedDate { get; set; }

    }

    public class UpdateCustomerDTO : CreateCustomerDTO
    {
        //public IList<CreateHoursDTO> Hours { get; set; }

        //public IList<CreateDaysDTO> Days { get; set; }

        public IList<CreateAuditDTO> Audit { get; set; }
    }

    public class CustomerDTO : CreateCustomerDTO
    {
        public int Id { get; set; }

        //public IList<HoursDTO> Hours { get; set; }

        //public IList<DaysDTO> Days { get; set; }

        public IList<AuditDTO> Audit { get; set; }
    }


}
