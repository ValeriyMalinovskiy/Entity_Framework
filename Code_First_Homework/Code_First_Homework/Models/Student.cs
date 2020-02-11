using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }

        public int GradeId { get; set; }

        public StudentAddress Address { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
