﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class JobGrade
    {
        [Key,StringLength(2)]
        public string GradeLevel { get; set; }

        public decimal LowestSalary { get; set; }

        public decimal HighestSalary { get; set; }
    }
}
