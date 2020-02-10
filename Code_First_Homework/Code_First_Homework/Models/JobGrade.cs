using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Code_First_Homework.Models
{
    public class JobGrade
    {
        [Key]
        public string GradeLevel { get; set; }

        public decimal LowestSalary { get; set; }

        public decimal HighestSalary { get; set; }
    }
}
