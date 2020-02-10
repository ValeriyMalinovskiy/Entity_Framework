using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Code_First_Homework.Models
{
    public class Region
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
