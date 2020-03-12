using System;
using System.Collections.Generic;
using UniversityDAL;
using UniversityDAL.Models;

namespace University.ConsoleUI
{
    internal delegate void OptionDelegate(UniversityDbEventArgs args);

    internal class ConsoleUI
    {
        private readonly UniversityDbEventArgs universityEvent = new UniversityDbEventArgs();

        public event OptionDelegate OptionSelected;

        public void ShowDialog()
        {
            Console.WriteLine("1 - View the list of all entities and properties");
            Console.WriteLine("2 - Add new Student");
            Console.WriteLine("3 - Add new Course");
            Console.WriteLine("4 - Add new Department");
            Console.WriteLine("5 - Delete Student");
            Console.WriteLine("6 - Delete Course");
            Console.WriteLine("7 - Delete Department");
            Console.WriteLine("8 - Update Student");
            Console.WriteLine("9 - Update Course");
            Console.WriteLine("0 - Update Department");
            Console.WriteLine("ESC - Exit");
        }

        public void ShowAll(UnitOfWork unitOfWork)
        {
            Console.Write(Environment.NewLine);
            List<Student> tempStudList = unitOfWork.StudentRepository.GetEntities();
            String s = String.Format("{0,-15} {1,-15} {2,-15}\n\n", "First Name", "Last Name", "Course");
            for (int index = 0; index < tempStudList.Count; index++)
                if (tempStudList[index].Course != null)
                {
                    s += String.Format("{0,-15} {1,-15} {2,-15}\n",
                                       tempStudList[index].FirstName, tempStudList[index].LastName, tempStudList[index].Course.Name);
                }
            Console.WriteLine($"\n{s}");

            Console.Write(Environment.NewLine);
            List<Course> tempCourseList = unitOfWork.CourseRepository.GetEntities();
            String crs = String.Format("{0,-15} {1,-15}\n\n", "Course Name", "Department");
            for (int index = 0; index < tempCourseList.Count; index++)
                if (tempCourseList[index].Department != null)
                {
                    crs += String.Format("{0,-15} {1,-15}\n",
                                       tempCourseList[index].Name, tempCourseList[index].Department.Name);
                }
            Console.WriteLine($"\n{crs}");

            Console.Write(Environment.NewLine);
            List<Department> tempDepartmentList = unitOfWork.DepartmentRepository.GetEntities();
            String dpts = String.Format("{0,-15} \n\n", "Department Name");
            for (int index = 0; index < tempDepartmentList.Count; index++)
            //if (tempCourseList[index].Department!=null)
            {
                dpts += String.Format("{0,-15} \n",
                                   tempDepartmentList[index].Name);
            }
            Console.WriteLine($"\n{dpts}");
        }

        public virtual void OnOptionSelected(UniversityDbOption option)
        {
            this.universityEvent.Option = option;
            OptionSelected(this.universityEvent);
        }

        public void ProcessUserInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        OnOptionSelected(UniversityDbOption.AddStudent);
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                        OnOptionSelected(UniversityDbOption.AddCourse);
                    }
                    break;
                case ConsoleKey.NumPad4:
                    {
                        OnOptionSelected(UniversityDbOption.AddDepartment);
                    }
                    break;
                case ConsoleKey.NumPad5:
                    {
                        OnOptionSelected(UniversityDbOption.DeleteStudent);
                    }
                    break;
                case ConsoleKey.NumPad6:
                    {
                        OnOptionSelected(UniversityDbOption.DeleteCourse);
                    }
                    break;
                case ConsoleKey.NumPad7:
                    {
                        OnOptionSelected(UniversityDbOption.DeleteDepartment);
                    }
                    break;
                case ConsoleKey.NumPad8:
                    {
                        OnOptionSelected(UniversityDbOption.UpdateStudent);
                    }
                    break;
                case ConsoleKey.NumPad9:
                    {
                        OnOptionSelected(UniversityDbOption.UpdateCourse);
                    }
                    break;
                case ConsoleKey.NumPad0:
                    {
                        OnOptionSelected(UniversityDbOption.UpdateDepartment);
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        OnOptionSelected(UniversityDbOption.Exit);
                    }
                    break;
            }
        }
        public Course SelectExistingCourse(UnitOfWork unitOfWork)
        {
            Console.Write(Environment.NewLine);
            int counter = 1;
            Course[] courses = unitOfWork.CourseRepository.GetEntities().ToArray();
            foreach (var course in courses)
            {
                Console.WriteLine(counter + " " + course.Name);
                counter++;
            }
            Console.WriteLine("Select Course");
            return courses[Convert.ToInt32(Console.ReadLine()) - 1];
        }

        public Department SelectExistingDepartment(UnitOfWork unitOfWork)
        {
            Console.Write(Environment.NewLine);
            int counter = 1;
            Department[] departments = unitOfWork.DepartmentRepository.GetEntities().ToArray();
            foreach (var department in departments)
            {
                Console.WriteLine(counter + " " + department.Name);
                counter++;
            }
            Console.WriteLine("Select Department");
            return departments[Convert.ToInt32(Console.ReadLine()) - 1];
        }

        public string EnterName(string name, string entityType)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine($"Enter {entityType} {name}");
            return Console.ReadLine();
        }
    }
}
