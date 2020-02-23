using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<Student> Students { get; set; }
        public Course()
        {
            this.Students = new List<Student>();
        }
    }
}
