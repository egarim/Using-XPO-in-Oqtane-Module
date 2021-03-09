using System;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Oqtane.Models;

namespace BIT.Customer.Models
{
    [Persistent("BITCustomer")]
    public class Customer :IAuditable
    {
       

        [Key(true)]
        public int CustomerId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
