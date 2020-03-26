using System;
using UniversityDAL.Models;
using UniversityDAL.Repositories;

namespace UniversityDAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly UniversityDbContext context = new UniversityDbContext();
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
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(this.context);
                }
                return this.departmentRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(this.context);
                }
                return this.studentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(this.context);
                }
                return this.courseRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
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
    }
}
