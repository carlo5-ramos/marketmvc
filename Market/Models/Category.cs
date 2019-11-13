using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Category
    {
        [Key]
        public int CateoryID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Description")]
        [StringLength(30, ErrorMessage = "The field{0} must be betwen  {2} and {1} characters", MinimumLength = 1)]
        public string Description { get; set; }
    }
}