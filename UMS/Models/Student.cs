using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(80), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public string Semester { get; set; }

    }
}
