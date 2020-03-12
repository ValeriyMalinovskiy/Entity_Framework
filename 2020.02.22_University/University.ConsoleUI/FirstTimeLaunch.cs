﻿using UniversityDAL;
using UniversityDAL.Models;

namespace University.ConsoleUI
{
    internal class FirstTimeLaunch
    {
        public UnitOfWork GenerateFirstEntries()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Department tempDepartment = new Department { Name = "IT" };
            Course tempCourse = new Course { Department = tempDepartment, Name = "2020-21" };
            tempDepartment.Courses.Add(tempCourse);
            unitOfWork.StudentRepository.Insert(new Student
            {
                FirstName = "Vasya",
                LastName = "Bulkin",
                Course = tempCourse
            });
            unitOfWork.StudentRepository.Insert(new Student
            {
                FirstName = "Petya",
                LastName = "Ivanov",
                Course = tempCourse
            });
            unitOfWork.Save();
            return unitOfWork;
        }
    }
}
