#include <iostream>
#include "Lines.h"

int main() 
{
	Lines W1;
	Lines W2(1, 2, 6, 4);
	Lines W3(W2);

	std::cout << "Line 3 coordinates before movement: " << W3.x1d << " " << W3.y1d << " " << W3.x2d << " " << W3.y2d << "\n";

	W3.MoveXL(3, 3);
	std::cout << "Line 3 coordinates after movement: " << W3.x1d << " " << W3.y1d << " " << W3.x2d << " " << W3.y2d << "\n";

	W1 = W2 + W3;

	std::cout << "Line 1 coordinates after adding Line 2 and Line 3: " << W1.x1d << " " << W1.y1d << " " << W1.x2d << " " << W1.y2d << "\n";

	return 0;
}