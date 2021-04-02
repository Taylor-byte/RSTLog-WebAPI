using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CreateAuditDTO
    {

        

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int TransTypeId { get; set; }

        //[ForeignKey(nameof(ApiUser))]
        //public int ApiUserId { get; set; }

        //public ApiUser ApiUser { get; set; }

        public DateTime Date { get; set; }

        public DateTime RecordDate { get; set; }

        public int Qty { get; set; }

        public string Comments { get; set; }

    }

    public class UpdateAuditDTO : CreateAuditDTO
    {

    }

    public class AuditDTO : CreateAuditDTO
    {
        public int Id { get; set; }

        //public IList<HoursDTO> Hours { get; set; }

        public IList<CustomerDTO> Customer { get; set; }

        public IList<EmployeeDTO> Employee { get; set; }
    }
}
