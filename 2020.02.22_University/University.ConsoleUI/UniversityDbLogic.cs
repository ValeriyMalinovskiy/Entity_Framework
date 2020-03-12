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
                        this.unitOfWork.StudentRepository.Insert(new Student
                        {
                            FirstName = this.ui.EnterName("First Name", "Student"),
                            LastName = this.ui.EnterName("Last Name", "Student"),
                            Course = this.ui.SelectExistingCourse(this.unitOfWork)
                        });
                    }
                    break;
                case UniversityDbOption.AddCourse:
                    {
                        this.unitOfWork.CourseRepository.Insert(new Course
                        {
                            Name = this.ui.EnterName("Name", "Course"),
                            Department = this.ui.SelectExistingDepartment(this.unitOfWork)
                        });
                    }
                    break;
                case UniversityDbOption.AddDepartment:
                    {
                        this.unitOfWork.DepartmentRepository.Insert(new Department
                        {
                            Name = this.ui.EnterName("Name", "Department")
                        });
                    }
                    break;
                case UniversityDbOption.DeleteStudent:
                    {
                        this.unitOfWork.StudentRepository.Delete(this.ui.SelectExistingStudent(this.unitOfWork));
                        this.unitOfWork.Save();
                    }
                    break;
                case UniversityDbOption.DeleteCourse:
                    {
                        this.unitOfWork.CourseRepository.Delete(this.ui.SelectExistingCourse(this.unitOfWork));
                    }
                    break;
                case UniversityDbOption.DeleteDepartment:
                    {
                        this.unitOfWork.DepartmentRepository.Delete(this.ui.SelectExistingDepartment(this.unitOfWork));
                    }
                    break;
                case UniversityDbOption.UpdateStudent:
                    {
                        var tempStudent = this.ui.SelectExistingStudent(this.unitOfWork);
                        tempStudent.FirstName = this.ui.EnterName("New First Name", "Student");
                        tempStudent.LastName = this.ui.EnterName("New Last Name", "Student");
                        tempStudent.Course = this.ui.SelectExistingCourse(this.unitOfWork);
                        this.unitOfWork.StudentRepository.Update(tempStudent);
                    }
                    break;
                case UniversityDbOption.UpdateCourse:
                    {
                        var tempCourse = this.ui.SelectExistingCourse(this.unitOfWork);
                        tempCourse.Name  = this.ui.EnterName("New Name", "Course");
                        tempCourse.Department = this.ui.SelectExistingDepartment(this.unitOfWork);
                        this.unitOfWork.CourseRepository.Update(tempCourse);
                    }
                    break;
                case UniversityDbOption.UpdateDepartment:
                    {
                        var tempDepartment = this.ui.SelectExistingDepartment(this.unitOfWork);
                        tempDepartment.Name = this.ui.EnterName("New Name", "Department");
                        this.unitOfWork.DepartmentRepository.Update(tempDepartment);
                    }
                    break;
                case UniversityDbOption.Exit:
                    {
                        System.Environment.Exit(1);
                    }
                    break;
            }
            this.unitOfWork.Save();
        }
    }
}
