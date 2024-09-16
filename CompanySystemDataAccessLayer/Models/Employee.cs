using CompanySystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompanySystemDataAccessLayer.Models
{
    public class Employee : BaseEntity
    {
       

       

        [Range(18, 65, ErrorMessage = "Age must be between 22 and 65.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, periods, and hyphens.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        [Required(ErrorMessage = "Hire date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public int? WorkForId { get; set; } //fk
      public Department WorkFor { get; set; }
    }
}
