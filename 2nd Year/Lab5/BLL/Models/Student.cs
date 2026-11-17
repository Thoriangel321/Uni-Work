using Lab5.BLL.Interfaces;

namespace Lab5.BLL.Models
{
    public class Student : IBicycleRider
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string StudentCard { get; set; }
        public string Passport { get; set; }

        public string RideBicycle()
        {
            return $"{FirstName} {LastName} rides a bicycle";
        }
    }
}