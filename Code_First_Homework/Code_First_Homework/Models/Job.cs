using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Code_First_Homework.Models
{
    public class Job
    {
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(35)]
        public string Title { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
