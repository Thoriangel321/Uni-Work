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

void Lines::Add(Lines line) 
{
	std::cerr << "Dummy Method";
}

void Lines::Add(Lines line, Lines line2) 
{

	x1d = line.x1 + line2.x1;
	this->x1 = x1d;
	y1d = line.y1 + line2.y1;
	this->y1 = y1d;
	x2d = line.x2 + line2.x2;
	this->x2 = x2d;
	y2d = line.y2 + line2.y2;
	this->y2 = y2d;

}

void Lines::Subtraction(Lines line) 
{
	std::cerr << "Very Dummy Method";
}

void Lines::Subtraction(Lines line, Lines line2) 
{
	x1d = line.x1 - line2.x1;
	this->x1 = x1d;
	y1d = line.y1 - line2.y1;
	this->y1 = y1d;
	x2d = line.x2 - line2.x2;
	this->x2 = x2d;
	y2d = line.y2 - line2.y2;
	this->y2 = y2d;

}