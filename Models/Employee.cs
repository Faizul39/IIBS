using System.ComponentModel.DataAnnotations;

namespace IIBS.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]

        [Required]
        [StringLength(100)]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100)]
        public string Last_Name { get; set; }
        
        public string Division { get; set; }
        [Display(Name = "Title & Room")]
        [Required]
        [StringLength(100)]
        public string Title_and_Room { get; set; }
    }
}
