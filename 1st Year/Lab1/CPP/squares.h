#include <cmath>
#include <vector>

class Square
{
	public:
		std::vector<double> points;
	
		double square()
		{ 
			double length = sqrt(pow((points[2] - points[0]), 2) + pow((points[3]-points[1]), 2));
			return (length * length);
		}
		double perimeter() 
		{
			double length = sqrt(pow((points[2] - points[0]), 2) + pow((points[3]-points[1]), 2));
			return 4*length;
		}
};
