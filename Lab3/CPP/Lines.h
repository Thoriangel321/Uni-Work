#pragma once

class Lines
{
	private:
		double x1{}, x2{}, y1{}, y2{};
	public:
		double x1d{}, x2d{}, y1d{}, y2d{};

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

	};

	~Lines();

	Lines(Lines& line) 
	{
		x1d = line.x1d;
		this->x1 = x1d;
		x2d = line.x2d;
		this->x2 = x2d;
		y1d = line.y1d;
		this->y1 = y1d;
		y2d = line.y2d;
		this->y2 = y2d;
	}

	double Length(Lines line);
	void MoveXL(double x1, double x2);

	void Add(Lines line);
	void Add(Lines line, Lines line2);

	void Subtraction(Lines line);
	void Subtraction(Lines line, Lines line2);
};