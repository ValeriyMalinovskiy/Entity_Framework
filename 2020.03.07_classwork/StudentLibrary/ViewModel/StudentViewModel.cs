using System;
using System.Collections.ObjectModel;
using StudentLibrary.DAL.Model;
using StudentLibrary.DAL.Services;
using StudentLibrary.DelegateCommand;
using StudentLibrary.Extensions;
using StudentLibrary.ViewModelBase;

namespace StudentLibraryStudentLibrary.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {
        private ObservableCollection<Student> students;
        private Student selectedStudent;
        private readonly IStudentService studentService;

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            this.Students = new ObservableCollection<Student>();

            this.GetStudentsCommmand = new DelegateCommand(ExecuteGetStudents);
            this.SaveChangesCommand = new DelegateCommand(ExecuteSaveChanges, CanExecuteSaveStudents);
        }

        private bool CanExecuteSaveStudents()
        {
            return this.selectedStudent != null;
        }

        private void ExecuteSaveChanges()
        {
            this.studentService.SaveChanges();
        }

        private void ExecuteGetStudents()
        {
            this.Students = this.studentService.GetStudents().ToObservableCollection();
        }

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return this.selectedStudent; }
            set
            {
                this.selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand SaveChangesCommand { get; }

    }
}