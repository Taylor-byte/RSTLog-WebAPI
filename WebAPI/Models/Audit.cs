using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Audit
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey(nameof(TransType))]
        public int TransTypeId { get; set; }

        public TransType TransType { get; set; }

        //[ForeignKey(nameof(ApiUser))]
        //public int ApiUserId { get; set; }

        //public ApiUser ApiUser { get; set; }

        public DateTime Date { get; set; }

        public DateTime RecordDate { get; set; }

        public int Qty { get; set; }

        public string Comments { get; set; }







    }
}
