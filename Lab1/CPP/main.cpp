#include <iostream>
#include "squares.h"

int main() 
{
	//---------------------------
	Square square1;
	square1.points.push_back (2);
	square1.points.push_back (6);
	square1.points.push_back (8);
	square1.points.push_back (6);
	square1.points.push_back (2);
	square1.points.push_back (1);
	square1.points.push_back (8);
	square1.points.push_back (1);
	//----------------------------

	std::cout << "square's coordintes are: " << "\n";
	for(int i = 0; i <= 7; i++) 
	{
		std::cout << square1.points[i] << " ";
		if(i % 2 == 1)
			std::cout << "\n";
	}
	 
	std::cout << "square - " << square1.square() << " perimeter - " << square1.perimeter() << "\n";

	return 0;	
}
