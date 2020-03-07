using StudentLibrary.DAL.Model;
using System.Collections.Generic;

namespace StudentLibrary.DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();

        void SaveChanges();

        void RemoveStudent(Student student);
    }
}