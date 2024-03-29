﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Supplier Name")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Contact First Name")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Contact Last Name")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string ContactLastName { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}