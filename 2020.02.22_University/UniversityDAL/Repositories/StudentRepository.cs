using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityDAL.Models;

namespace UniversityDAL.Repositories
{
    public class StudentRepository : IDisposable, IStudentRepository
    {
        private readonly UniversityDbContext context;
        private bool disposed = false;

        public StudentRepository(UniversityDbContext context)
        {
            this.context = context;
        }
        public void DeleteStudent(int studentId)
        {
            Student student = this.context.Students.Find(studentId);
            this.context.Students.Remove(student);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
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
            this.context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            this.context.Entry(student).State = EntityState.Modified;
        }
    }
}
