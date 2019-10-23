using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The field{0} must be betwen  {1} and {2} characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field{0} must be betwen  {1} and {2} characters", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "0:C2", ApplyFormatInEditMode = false)]
        public decimal Salary { get; set; }

        [Display(Name = "Bonus Percent")]
        [DisplayFormat(DataFormatString = "0:P2", ApplyFormatInEditMode = false)]

        public float BonusPercent { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "0:hh:mm", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int DocumentTypeID { get; set; }

       
        public virtual DocumentType DocumentType { get; set; }
    }
}