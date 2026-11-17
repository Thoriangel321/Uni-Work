using Lab5.BLL.Interfaces;

namespace Lab5.BLL.Entities
{
    public class Librarian : IBicycleRider, IOnlineLearner
    {
        public string Name { get; set; }

        public string RideBicycle()
        {
            return $"Librarian {Name} rides a bicycle";
        }

        public string StudyOnline(bool hasInternet)
        {
            if (!hasInternet)
                return "No Internet connection for studying";

            return $"Librarian {Name} studies online";
        }
    }
}