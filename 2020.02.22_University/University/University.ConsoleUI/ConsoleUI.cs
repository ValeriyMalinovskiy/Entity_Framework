using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL;
using UniversityDAL.Models;

namespace University.ConsoleUI
{
    internal delegate void OptionDelegate(UniversityEventArgs args);

    class ConsoleUI
    {
        private readonly UniversityEventArgs universityEvent = new UniversityEventArgs();

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
            Console.WriteLine("5 - Update Student");
            Console.WriteLine("6 - Update Course");
            Console.WriteLine("7 - Update Department");
            Console.WriteLine("ESC - Exit");
        }

        public void ShowAll(UnitOfWork unitOfWork)
        {
            Console.Write(Environment.NewLine);
            List<Student> tempStudList = unitOfWork.StudentRepository.GetEntities();
            String s = String.Format("{0,-10} {1,-10} {2,-10}\n\n", "First Name", "Last Name", "Course");
            for (int index = 0; index < tempStudList.Count; index++)
            //if (tempStudList[index].Course!=null)
            {
                s += String.Format("{0,-10} {1,-10} {2,-10}\n",
                                   tempStudList[index].FirstName, tempStudList[index].LastName, tempStudList[index].Course.Name);
            }
            Console.WriteLine($"\n{s}");

            Console.Write(Environment.NewLine);
            List<Course> tempCourseList = unitOfWork.CourseRepository.GetEntities();
            String crs = String.Format("{0,-10} {1,-10}\n\n", "Course Name", "Department");
            for (int index = 0; index < tempCourseList.Count; index++)
            //if (tempCourseList[index].Department!=null)
            {
                crs += String.Format("{0,-10} {1,-10}\n",
                                   tempCourseList[index].Name, tempCourseList[index].Department.Name);
            }
            Console.WriteLine($"\n{crs}");
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
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        this.OnOptionSelected(UniversityDbOption.AddStudent);
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad4:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad5:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad6:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad7:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad8:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.NumPad9:
                    {
                        this.OnOptionSelected(UniversityDbOption.ShowAll);
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        this.OnOptionSelected(UniversityDbOption.Exit);
                    }
                    break;
            }
        }

    }
}
