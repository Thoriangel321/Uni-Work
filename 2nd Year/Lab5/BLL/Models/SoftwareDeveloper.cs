using Lab5.BLL.Interfaces;

namespace Lab5.BLL.Entities
{
    public class SoftwareDeveloper : IBicycleRider, IOnlineLearner
    {
        public string Name { get; set; }

        public string RideBicycle()
        {
            return $"SD {Name} rides a bicycle";
        }

        public string StudyOnline(bool hasInternet)
        {
            if (!hasInternet)
                return "No Internet connection for studying";

            return $"SD {Name} studies online";
        }
    }
}