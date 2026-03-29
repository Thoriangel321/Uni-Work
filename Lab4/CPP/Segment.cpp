#include <iostream>
#include "Segment.h"

Segment Segment::Extrude(Segment& seg) 
{
	seg.x1d = seg.x1d * 2;
	this->x1 = seg.x1d;
	seg.y1d = seg.y1d * 2;
	this->y1 = seg.y1d;
	seg.x2d = seg.x2d * 2;
	this->x2 = seg.x2d;
	seg.y2d = seg.y2d * 2;
	this->y2 = seg.y2d;

	return seg;
}