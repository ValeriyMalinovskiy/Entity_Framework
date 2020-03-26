﻿using System;
using System.Collections.Generic;
using UniversityDAL.Models;

namespace UniversityDAL.Repositories
{
    internal interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int studentId);

        void InsertStudent(Student student);

        void DeleteStudent(int studentId);

        void UpdateStudent(Student student);

        void Save();
    }
}
