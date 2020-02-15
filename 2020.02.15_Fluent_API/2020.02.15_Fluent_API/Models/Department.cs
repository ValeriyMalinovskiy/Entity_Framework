using System;
using System.Collections.Generic;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ManagerId { get; set; }

        public Location Location { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
