using System;
using System.Collections.Generic;
using System.Text;

namespace University.ConsoleUI
{
    class UniversityDbEventArgs : EventArgs
    {
        public UniversityDbOption Option { get; set; }
    }
}
