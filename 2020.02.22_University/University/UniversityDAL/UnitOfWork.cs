using System;
using UniversityDAL.Models;
using UniversityDAL.Repositories;

namespace UniversityDAL
{
    public class UnitOfWork : IDisposable
    {
        private UniversityDbContext context = new UniversityDbContext();
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Course> courseRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            this.context.UpdateRange();
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
