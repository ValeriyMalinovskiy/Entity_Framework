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

        public void PerformDbOperation(UniversityDbEventArgs universityEvent)
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
                        unitOfWork.StudentRepository.Insert(new Student{ FirstName = ui.EnterName("First Name", "Student"), LastName=ui.EnterName("Last Name", "Student"), Course = ui.SelectExistingCourse(unitOfWork) });
                        unitOfWork.Save();
                    }
                    break;
                case UniversityDbOption.AddCourse:
                    {
                        unitOfWork.CourseRepository.Insert(new Course { Name = ui.EnterName("Name", "Course"), Department = ui.SelectExistingDepartment(unitOfWork)});
                        unitOfWork.Save();
                    }
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

    }
}
