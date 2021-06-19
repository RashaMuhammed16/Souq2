using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
  public  class ProductViewModel
    {

        public int ID { get; set; }
        [Required]
        [MinLength(5)]
        //[RegularExpression("[a-zA-Z]{5,}", ErrorMessage = "Name must be only characters and more that 5")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid price")]
        public double Price { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Range(5, int.MaxValue, ErrorMessage = "Discout Must be more than 5")]
        public double Discount { get; set; }
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be more than 1")]
        public int Quantity { get; set; }
        public int Sub_Catogery_Id { get; set; }


        public int Model_Id { get; set; }
        public string SubCatgoryName { get; set; }
        public string ModelName { get; set; }
        public double? AverageRating { get; set; }
       // public Sub_Catogery Sub_Catogery  { get; set; }
    }
}
