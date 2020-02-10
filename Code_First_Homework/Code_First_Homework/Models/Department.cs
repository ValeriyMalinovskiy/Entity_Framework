using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int ManagerId { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
