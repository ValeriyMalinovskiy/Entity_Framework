using System;
using System.Collections.Generic;
using UniversityDAL.Models;
using UniversityDAL;
using UniversityDAL.Repositories;

namespace University.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitofwork = new UnitOfWork();
            Department tempDepartment = new Department { Name = "IT" };
            Course tempCourse = new Course { Department = tempDepartment, Name = "2020-21" };
            tempDepartment.Courses.Add(tempCourse);
            unitofwork.StudentRepository.Insert(new Student { FirstName = "Vasya", LastName = "Bulkin", Course = tempCourse });
            unitofwork.StudentRepository.Insert(new Student { FirstName = "Petya", LastName = "Ivanov", Course = tempCourse });
            unitofwork.Save();

            Console.WriteLine("1 - View the list of all entities and properties");
            Console.WriteLine("2 - Add new Student");
            Console.WriteLine("3 - Add new Course");
            Console.WriteLine("4 - Add new Department");
            Console.WriteLine("5 - Delete Student");
            Console.WriteLine("6 - Delete Course");
            Console.WriteLine("7 - Delete Department");
            Console.WriteLine("5 - Update Student");
            Console.WriteLine("6 - Update Course");
            Console.WriteLine("7 - Update Department");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        int tempTop = Console.CursorTop;
                        int tempLeft = Console.CursorLeft;
                        Console.SetCursorPosition(tempLeft - 1, tempTop);
                        Console.WriteLine("Loading");

                        ShowAll(unitofwork);
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                    }
                    break;
                case ConsoleKey.NumPad4:
                    {
                    }
                    break;
                case ConsoleKey.NumPad5:
                    {
                    }
                    break;
                case ConsoleKey.NumPad6:
                    {
                    }
                    break;
                case ConsoleKey.NumPad7:
                    {
                    }
                    break;
            }
        }

        public static void ShowAll(UnitOfWork unitofwork)
        {
            Console.Write(Environment.NewLine);
            List<Student> tempStudList = unitofwork.StudentRepository.GetEntities();
            String s = String.Format("{0,-10} {1,-10} {2,-10}\n\n", "First Name", "Last Name", "Course");
            for (int index = 0; index < tempStudList.Count; index++)
                if (tempStudList[index].Course!=null)
                {
                    s += String.Format("{0,-10} {1,-10} {2,-10}\n",
                                       tempStudList[index].FirstName, tempStudList[index].LastName, tempStudList[index].Course.Name);
                }
            Console.WriteLine($"\n{s}");

            Console.Write(Environment.NewLine);
            List<Course> tempCourseList = unitofwork.CourseRepository.GetEntities();
            String crs = String.Format("{0,-10} {1,-10}\n\n", "Course Name", "Department");
            for (int index = 0; index < tempCourseList.Count; index++)
                if (tempCourseList[index].Department!=null)
                {
                    crs += String.Format("{0,-10} {1,-10}\n",
                                       tempCourseList[index].Name, tempCourseList[index].Department.Name);
                }
            Console.WriteLine($"\n{crs}");
        }
    }
}
