using StudentLibrary.DAL.Services;
using StudentLibraryStudentLibrary.ViewModel;

namespace StudentLibrary.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IStudentService studentService;

        public ViewModelLocator()
        {
            this.studentService = new StudentService();
        }

        public StudentViewModel StudentViewModel => new StudentViewModel(this.studentService);
    }
}