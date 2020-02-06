using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entity_Framework_solution.Model
{
    public class Grade
    {
        [Column(TypeName ="bigint")]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
