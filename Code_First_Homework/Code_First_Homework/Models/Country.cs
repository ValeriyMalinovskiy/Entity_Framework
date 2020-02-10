using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Code_First_Homework.Models
{
    public class Country
    {
        [MaxLength(2), MinLength(2),Key]
        public string Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
