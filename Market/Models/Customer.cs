using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Document")]
        [StringLength(30, ErrorMessage = "The field{0} must contain between  {2} and {1} characters", MinimumLength = 1)]
        public string Document { get; set; }

        public int DocumentTypeID { get; set; }


        public virtual DocumentType DocumentType { get; set; }
    }
}