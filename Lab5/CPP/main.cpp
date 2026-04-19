#include <iostream>
#include <string>
#include "Lines.h"
#include "Letters.h"
#include "Digits.h"

int main() 
{
	std::string letters = "abcdefg";
	std::string digits = "2026";

	Letters letobj(letters);
	Digits digitobj(digits);

	std::cout << "the length of letters string is - " << letobj.GetLength() << " and the processed string is - " << letobj.Process() << "\n";
	std::cout << "the length of digits string is - " << digitobj.GetLength() << " and the processed string is - " << digitobj.Process() << "\n";

	return 0;
}