using Code_First_Homework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code_First_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var context = new CourseCampContext();
            var stud = context.Students.Where(s => s.Name == "Vasya").FirstOrDefault();
            //    .Include(s => s.Grade)
            //    .Include(s => s.Address)
            //    .Include(s=> s.StudentCourses)
            //    .ThenInclude(sc => sc.Course)
            //    .FirstOrDefault();

            //context.Entry(stud).Reference(s => s.Address).Load();
            // context.Entry(stud).Collection(s => s.StudentCourses).Load();
        }
    }
}
