using StudentLibrary.DAL.Model;
using System.Collections.Generic;

namespace StudentLibrary.DAL.Services
{
    public class StudentService : IStudentService
    {
        private List<Student> studentsRepository = new List<Student>
        {
            new Student {FirstName = "John Snow", Email = "John.Snow@soaf.com"},
            new Student {FirstName = "Tyrion Lannister", Email = "Tyrion.Lannister@soaf.com"},
            new Student {FirstName = "Arya Stark", Email = "Arya.Stark@soaf.com"},
            new Student {FirstName = "Victarion.Greyjoy", Email = "Victarion.Greyjoy@soaf.com"},
        };

        public IEnumerable<Student> GetStudents()
        {
            return this.studentsRepository;
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            this.studentsRepository = new List<Student>(students);
        }
    }
}