#include <iostream>
#include <cmath>
#include "Lines.h"

Lines::~Lines() 
{
}

void Lines::MoveXL(double x1, double x2) 
{
	this->x1d -= x1;
	this->x1 = x1d;
	this->x2d -= x2;
	this->x2 = x2d;
}

double Lines::Length(Lines line) 
{
	return (sqrt(pow(line.x2 - line.x1, 2) + pow(line.y2 - line.y1, 2)));
}


Lines Lines::operator+(Lines line) 
{

	x1d = x1 + line.x1;
	this->x1 = x1d;
	y1d = y1 + line.y1;
	this->y1 = y1d;
	x2d = x2 + line.x2;
	this->x2 = x2d;
	y2d = y2 + line.y2;
	this->y2 = y2d;

	Lines retLine(x1, y1, x2, y2);
	return retLine;
}


Lines Lines::operator-(Lines line) 
{
	x1d = x1 - line.x1;
	this->x1 = x1d;
	y1d = y1 - line.y1;
	this->y1 = y1d;
	x2d = x2 - line.x2;
	this->x2 = x2d;
	y2d = y2 - line.y2;
	this->y2 = y2d;
	
	Lines retLine(x1, y1, x2, y2);

	return retLine;
}