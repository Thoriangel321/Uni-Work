#pragma once
#include <string>
#include "Lines.h"

class Letters : public Lines 
{

	private:
		std::string mainstr;

	public:
		std::string str;

		Letters() 
		{

		}
		
		Letters(std::string par_string) 
		{
			str = par_string;
			mainstr = str;
		}

		int GetLength() override;
		std::string Process() override;

};