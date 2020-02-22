using System;
using UniversityDAL.Repositories;

namespace University.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentRepo = new StudentRepository(new UniversityDAL.Models.UniversityDbContext());
            studentRepo.InsertStudent(new UniversityDAL.Models.Student{ FirstName = "Vasya", LastName = "Pupkin" });
            studentRepo.Save();
            foreach (var item in studentRepo.GetStudents())
            {
                Console.WriteLine(item);
            }
        }
    }
}
