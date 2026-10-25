using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DAL.Entities
{
    public class SoftwareDeveloperEntity : Interfaces.IBicycleRider
    {
        public void RideBicycle() => System.Console.WriteLine("Software Developer rides a bicycle");
    }
}
