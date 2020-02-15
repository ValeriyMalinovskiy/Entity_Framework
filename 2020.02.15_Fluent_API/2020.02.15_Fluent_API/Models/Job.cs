using System;
using System.Collections.Generic;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class Job
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
