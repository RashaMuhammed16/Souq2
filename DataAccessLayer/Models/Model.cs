using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Model
    {
        public int ID { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public string BrandName
        {
           
            get
            {
                if (this.Brand != null)
                    return this.Brand.Name;
                return "";

            }
        }
        public List<Product> products { get; set; } = new List<Product>();

    }
}
