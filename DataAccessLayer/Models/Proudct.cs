using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("Product")]
  public class Product 
    { 

    public int ID { get; set; }
    [Required]
    [MinLength(5)]
    //[RegularExpression("[a-zA-Z]{5,}", ErrorMessage = "Name must be only characters and more that 5")]
    public string Name { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Please enter valid price")]
    public double Price { get; set; } //make it double instead of nullable

    [Required]
    [MinLength(10)]
    public string Description { get; set; }

    [Required]
    [Range(5, int.MaxValue, ErrorMessage = "Discout Must be more than 5")]
    public double Discount { get; set; }

    public string Image { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be more than 1")]
    public int Quantity { get; set; }

    [NotMapped]
    public double? AverageRating
    {
        get
        {
            if (Rates.Count != 0)
                return Rates.Select(r => r.Rating).Average();
            return 0;
        }
    }
        public string SubCatgoryName { get
            {
                if (this.Sub_Catogery != null)
                return this.Sub_Catogery.Name;
                return "";

            }
        }
        public string ModelName
        {
            get
            {
                if (this.Model != null)
                    return this.Model.Name;
                return "";

            }
        }

        [ForeignKey("Sub_Catogery")]
        public int Sub_Catogery_Id { get; set; }
        public Sub_Catogery Sub_Catogery { get; set; }
        [ForeignKey("Model")]
        public int Model_Id { get; set; }
        public Model Model { get; set; }

        public List<ProductWishList> Wishlists { get; set; } = new List<ProductWishList>();

    public List<OrderDetails> OrderProducts { get; set; } = new List<OrderDetails>();
    public List<Rate> Rates { get; set; } = new List<Rate>();


}
}
