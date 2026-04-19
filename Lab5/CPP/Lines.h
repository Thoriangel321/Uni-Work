#pragma once
#include <string>

class Lines 
{
	private:
	public:
		virtual int GetLength() = 0;
		virtual std::string Process() = 0;

		//virtual ~Lines();

};