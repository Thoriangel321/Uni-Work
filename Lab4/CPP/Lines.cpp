#include <iostream>
#include "Lines.h"
#include <cmath>

Lines::~Lines() 
{
}

double Lines::Length(Lines line) 
{
	return (sqrt(pow(line.x2 - line.x1, 2) + pow(line.y2 - line.y1, 2)));
}