using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DAL.Entities
{
    public class LibrarianEntity : Interfaces.IBicycleRider
    {
        public void RideBicycle() => System.Console.WriteLine("Librarian rides a bicycle");
    }

}
