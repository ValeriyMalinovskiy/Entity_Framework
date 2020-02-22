using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
