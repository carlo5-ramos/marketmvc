using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Product Description")]
        [StringLength(30, ErrorMessage = "The field{0} must be betwen  {2} and {1} characters", MinimumLength = 1)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public float Quantity { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}