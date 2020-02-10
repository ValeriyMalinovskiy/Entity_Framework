using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string StreeAddress { get; set; }

        [MaxLength(12)]
        public string PostalCode { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(12)]
        public string StateProvince { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
