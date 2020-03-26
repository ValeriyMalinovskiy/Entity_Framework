namespace University.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UniversityDbLogic dbLogic = new UniversityDbLogic();
            dbLogic.UtilizeUniversityDb();
        }
    }
}
