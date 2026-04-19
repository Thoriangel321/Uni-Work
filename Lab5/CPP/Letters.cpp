#include <iostream>
#include <string>
#include <algorithm>
#include "Letters.h"


int Letters::GetLength() 
{
	return str.length();
}

std::string Letters::Process() 
{
	std::string ret = str;
	std::reverse(ret.begin(), ret.end());
	return ret;
}
