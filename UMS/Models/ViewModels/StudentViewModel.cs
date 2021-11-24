using System.Collections.Generic;
using UMS.Models;

namespace UMS.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
