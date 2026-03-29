#pragma once
#include "Lines.h"

class Segment : public Lines
{


public:
	Segment() 
	{

	}

	Segment(double X1, double Y1, double X2, double Y2) : Lines(X1, Y1, X2, Y2)
	{

	}


	Segment Extrude(Segment& seg);
};