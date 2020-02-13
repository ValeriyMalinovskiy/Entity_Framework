using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Grade Grade { get; set; }

        public int GradeId { get; set; }

        public virtual StudentAddress Address { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
