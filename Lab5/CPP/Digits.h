#pragma once
#include <iostream>
#include <string>
#include "Lines.h"

class Digits : public Lines 
{

	private:
		std::string mainDigits;
	public:
		std::string digits;

		Digits() {};
		Digits(std::string str) 
		{
			digits = str;
			mainDigits = digits;
		}

		int GetLength() override;
		std::string Process() override;

};