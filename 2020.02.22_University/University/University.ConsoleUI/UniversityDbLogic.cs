using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL;
using UniversityDAL.Models;

namespace University.ConsoleUI
{
    class UniversityDbLogic
    {
        //var firstTimeLaunch = new FirstTimeLaunch();
        //UnitOfWork unitOfWork = firstTimeLaunch.GenerateFirstEntries();
        bool exit = false;
        UnitOfWork unitOfWork = new UnitOfWork();
        ConsoleUI ui = new ConsoleUI();

        public void UtilizeUniversityDb()
        {
            ui.OptionSelected += PerformDbOperation;
            while (!exit)
            {
                ui.ShowDialog();
                ui.ProcessUserInput();
            }
        }

        public void PerformDbOperation(UniversityEventArgs universityEvent)
        {
            switch (universityEvent.Option)
            {
                case UniversityDbOption.ShowAll:
                    {
                        ui.ShowAll(this.unitOfWork);
                    }
                    break;
                case UniversityDbOption.AddStudent:
                    {
                        Console.WriteLine();
                        unitOfWork.StudentRepository.Insert(new Student { FirstName = Console.ReadLine(), LastName = Console.ReadLine(), Course = GetCoursesList() });
                        unitOfWork.Save();
                    }
                    break;
                case UniversityDbOption.AddCourse:
                    break;
                case UniversityDbOption.AddDepartment:
                    break;
                case UniversityDbOption.DeleteStudent:
                    break;
                case UniversityDbOption.DeleteCourse:
                    break;
                case UniversityDbOption.DeleteDepartment:
                    break;
                case UniversityDbOption.UpdateStudent:
                    break;
                case UniversityDbOption.UpdateCourse:
                    break;
                case UniversityDbOption.UpdateDepartment:
                    break;
                case UniversityDbOption.Exit:
                    break;
            }
        }

        private Course GetCoursesList()
        {
            Console.Clear();
            int counter = 1;
            Course[] courses = this.unitOfWork.CourseRepository.GetEntities().ToArray();
            foreach (var course in courses)
            {
                Console.WriteLine(counter + " " + course.Name);
                counter++;
            }
            Console.WriteLine("Select Course");
            return courses[Convert.ToInt32(Console.ReadLine()) - 1];
        }
    }
}
