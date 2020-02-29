using System;
using System.Collections.Generic;

namespace _2020._02._15_Fluent_API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public decimal CommissionPct { get; set; }

        public int ManagerId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
