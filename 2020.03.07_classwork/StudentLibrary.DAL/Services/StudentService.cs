using StudentLibrary.DAL.Model;
using StudentLibrary.DAL.StudentLibraryDatabaseContext;
using System.Collections.Generic;

namespace StudentLibrary.DAL.Services
{
    public class StudentService : IStudentService
    {
        private StudentLibraryDbContext context { get; set; }
        //private List<Student> studentsRepository = new List<Student>
        //{
        //    new Student {FirstName = "John Snow", Email = "John.Snow@soaf.com"},
        //    new Student {FirstName = "Tyrion Lannister", Email = "Tyrion.Lannister@soaf.com"},
        //    new Student {FirstName = "Arya Stark", Email = "Arya.Stark@soaf.com"},
        //    new Student {FirstName = "Victarion.Greyjoy", Email = "Victarion.Greyjoy@soaf.com"},
        //};

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students;
        }

        public void RemoveStudent(Student student)
        {
            this.context.Students.Remove(student);
            this.context.SaveChanges();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}