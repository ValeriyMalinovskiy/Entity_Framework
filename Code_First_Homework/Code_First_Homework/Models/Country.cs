using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Homework.Models
{
    public class Country
    {
        [Key, StringLength(2)]
        public string Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
