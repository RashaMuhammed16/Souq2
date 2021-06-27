using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BillingAddress
    {
        public int ID { get; set; }
        public string street { get; set; }
        public string Phone { get; set; }
        public string ShipperName { get; set; }
        [ForeignKey("appUser")]
        public string ApplicationUserIdentity_Id { get; set; }
        public ApplicationUserIdentity appUser { get; set; }
         public List<Payment>Payment { get; set; } = new List<Payment>();
    }
}
