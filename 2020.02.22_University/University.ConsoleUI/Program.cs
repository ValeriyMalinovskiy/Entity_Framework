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
            UniversityDbLogic dbLogic = new UniversityDbLogic();
            dbLogic.UtilizeUniversityDb();
        }
    }
}
