#include <iostream>
#include <string>
#include "Digits.h"

int Digits::GetLength() 
{
	return digits.length();
}

std::string Digits::Process() 
{
	std::string ret = digits;
	return ret + digits;
}