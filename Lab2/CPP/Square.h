#pragma once
#include <cmath>

class Square 
{
	private:
		double coords[8] {};

	public:
		Square() 
		{

		}
		Square(double Coords[8])
		{
			for (int i = 0; i < sizeof(Coords); i++) 
			{
				coords[i] = Coords[i];
			}
		}
		~Square() 
		{
			
		}

		double square() 
		{
			double length = sqrt(pow(coords[2] - coords[0], 2) + pow(coords[3] - coords[1], 2));
			return (length * length);
		}
		double perimeter() 
		{
			double length = sqrt(pow(coords[2] - coords[0], 2) + pow(coords[3] - coords[1], 2));
			return (length * 4);
		}
};

