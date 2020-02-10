using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class JobHistory
    {
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }

        [Key, Column(Order = 2)]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
