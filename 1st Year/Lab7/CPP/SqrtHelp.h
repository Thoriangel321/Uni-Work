#pragma once
#include <cmath>
#include <stdexcept>
#include <string>

class SqrtHelp {
public:
    static double CalculateSquareRoot(double value) {
        if (value < 0) {
            throw std::out_of_range("Impossible to calculate a square root of a negative value: " + std::to_string(value) + ".");
        }
        return std::sqrt(value);
    }
};