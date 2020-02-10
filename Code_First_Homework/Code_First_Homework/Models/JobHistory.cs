using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Code_First_Homework.Models
{
    public class JobHistory
    {
        [Key,Column(Order=1)]
        public Employee Employee { get; set; }

        [Key, Column(Order = 2)]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
