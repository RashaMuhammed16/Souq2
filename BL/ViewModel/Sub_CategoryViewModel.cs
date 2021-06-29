using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class Sub_CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CatogeryId { get; set; }
        public string image { get; set; }
        // public Category Category { get; set; }
        //  public List<Product> Products { get; set; } = new List<Product>();
    }
}
