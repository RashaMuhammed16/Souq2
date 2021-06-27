using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
     public class Order
    {
        public int Id { get; set; }
         public int OrderNumber { get; set; }
        public double totalPrice { get; set; }
        public string Orderdate { get; set; }
        [ForeignKey("appUser")]
        public string ApplicationUserIdentity_Id { get; set; }
        public ApplicationUserIdentity appUser { get; set; }
        
       // public virtual Shipper ShipoperID { get; set; }
        public List<OrderDetails> orderDetails { get; set; } = new List<OrderDetails>();

    }
    
}
