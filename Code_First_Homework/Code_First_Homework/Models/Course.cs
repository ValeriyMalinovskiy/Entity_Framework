using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Homework.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<StudentCourse> StudentCourses { get; set; }
    }
}
