using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2020._02._15_Fluent_API.Models
{
    public class JobHistory
    {
        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Department Department { get; set; }

        public Job Job { get; set; }

        public Employee Employee { get; set; }
    }
}
