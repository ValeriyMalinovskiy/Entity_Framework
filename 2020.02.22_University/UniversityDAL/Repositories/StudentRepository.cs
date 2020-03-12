using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityDAL.Models;

namespace UniversityDAL.Repositories
{
    public class StudentRepository : IDisposable, IStudentRepository
    {
        private UniversityDbContext context;
        private bool disposed = false;

        public StudentRepository(UniversityDbContext context)
        {
            this.context = context;
        }
        public void DeleteStudent(int studentId)
        {
            Student student = context.Students.Find(studentId);
            context.Students.Remove(student);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Student GetStudentById(int studentId)
        {
            return this.context.Students.Find(studentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public void InsertStudent(Student student)
        {
            this.context.Students.Add(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }
    }
}
