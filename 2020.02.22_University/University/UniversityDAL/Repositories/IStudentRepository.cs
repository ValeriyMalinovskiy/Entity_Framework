﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Models;

namespace UniversityDAL.Repositories
{
    interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int studentId);

        void InsertStudent(Student student);

        void DeleteStudent(int studentId);

        void UpdateStudent(Student student);

        void Save();
    }
}
