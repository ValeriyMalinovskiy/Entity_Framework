using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Framework_solution.Model
{
    [Table("BestStudents")]
    public class Student
    {
        [Column(Order = 0)]
        public int StudentId { get; set; }
        [Column("StudentNAME", Order = 1)]
        public string Name { get; set; }
        [Column("I_know_where_you_live",Order = 3)]
        public StudentAddress Address { get; set; }
        [Column(Order = 2, TypeName ="bigint")]
        public int GradeId { get; set; }
        [Column(Order = 4)]
        public Grade Grade { get; set; }
    }
}
