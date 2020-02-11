using System;
using System.Collections.Generic;
using System.Text;

namespace Code_First_Homework.Models
{
    public class Grade
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
