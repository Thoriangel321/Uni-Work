#pragma once

class Lines
{
	protected: 
		double x1{}, y1{}, x2{}, y2{};
	
	public:
		double x1d{}, y1d{}, x2d{}, y2d{};

		Lines()
		{

		};

		Lines(double X1, double Y1, double X2, double Y2) 
		{
			x1d = X1;
			this->x1 = x1d;
			x2d = X2;
			this->x2 = x2d;
			y1d = Y1;
			this->y1 = y1d;
			y2d = Y2;
			this->y2 = y2d;
		}

		Lines(Lines& line) 
		{
			x1d = line.x1d;
			this->x1 = x1d;
			x2d = line.x2d;
			this->x2 = x2d;
			y1d = line. y1d;
			this->y1 = y1d;
			y2d = line.y2d;
			this->y2 = y2d;
		}

		~Lines();

		double Length(Lines line);
};