#include <iostream>
#include "Lines.h"
#include "Segment.h"

int main() 
{

	Segment seg(1, 2, 6, 4);

	std::cout << "Segments coordinates before extruding: " << seg.x1d << " " << seg.y1d << " " << seg.x2d << " " << seg.y2d << "\n";
	std::cout << "The Length of the segments before extruding is " << seg.Length(seg) << "\n";

	seg.Extrude(seg);
	std::cout << "Segments coordinates after extruding: " << seg.x1d << " " << seg.y1d << " " << seg.x2d << " " << seg.y2d << "\n";
	std::cout << "The Length of the segments after extruding is " << seg.Length(seg);


	return 0;
}