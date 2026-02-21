#include <iostream>
#include "Square.h"

double points[8]{};

void Input() 
{
	for (int i = 0; i <= 7; i++) 
	{
		std::cin >> points[i];
	}
}

int main() 
{
	Input();
	Square square(points);

	std::cout << "square - " << square.square() << " perimeter - " << square.perimeter();

	return 0;
}