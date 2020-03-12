using UniversityDAL;
using UniversityDAL.Models;

namespace University.ConsoleUI
{
    internal class UniversityDbLogic
    {
        private readonly bool exit = false;
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private readonly ConsoleUI ui = new ConsoleUI();

        public void UtilizeUniversityDb()
        {
            //
            //Uncomment for the first time launch after DB creaation
            //
            //var firstTimeLaunch = new FirstTimeLaunch();
            //UnitOfWork unitOfWork = firstTimeLaunch.GenerateFirstEntries();

            this.ui.OptionSelected += PerformDbOperation;
            while (!this.exit)
            {
                this.ui.ShowDialog();
                this.ui.ProcessUserInput();
            }
        }

        public void PerformDbOperation(UniversityDbEventArgs universityEvent)
        {
            switch (universityEvent.Option)
            {
                case UniversityDbOption.ShowAll:
                    {
                        this.ui.ShowAll(this.unitOfWork);
                    }
                    break;
                case UniversityDbOption.AddStudent:
                    {
                        this.unitOfWork.StudentRepository.Insert(new Student { FirstName = this.ui.EnterName("First Name", "Student"), LastName = this.ui.EnterName("Last Name", "Student"), Course = this.ui.SelectExistingCourse(this.unitOfWork) });
                        this.unitOfWork.Save();
                    }
                    break;
                case UniversityDbOption.AddCourse:
                    {
                        this.unitOfWork.CourseRepository.Insert(new Course { Name = this.ui.EnterName("Name", "Course"), Department = this.ui.SelectExistingDepartment(this.unitOfWork) });
                        this.unitOfWork.Save();
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
