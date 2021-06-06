using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ShipperViewModel
    {
   
        public int ID { get; set; }
        [Required]
        public string ShipperMethod { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public int BillingAddressId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime shipper_date
        {
            get; set;
        }
    }
}
