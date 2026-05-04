#pragma once
#include "SqrtHelp.h"
#include <string>
#include <stdexcept>

class ExpressionEvaluator {
public:
    double A;
    double B;
    double C;
    double D;

    ExpressionEvaluator() : A(0), B(0), C(0), D(0) {}

    ExpressionEvaluator(double a, double b, double c, double d) : A(a), B(b), C(c), D(d) {}

    void SetValues(double a, double b, double c, double d) {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    std::string ToString() const {
        return "a = " + std::to_string(A) + ", b = " + std::to_string(B) +
            ", c = " + std::to_string(C) + ", d = " + std::to_string(D);
    }

    double Calculate() {
        try {
            double numerator = CalculateNumerator();
            double denominator = CalculateDenominator();
            return numerator / denominator;
        }
        catch (const std::exception& ex) {
            throw std::runtime_error("Unexpected error with this object -  [" + ToString() + "]. " + ex.what());
        }
    }

private:
    double CalculateNumerator() const {
        return 1 + A - (B / 2.0);
    }

    double CalculateDenominator() const {
        try {
            if (B == 0) {
                throw std::runtime_error("b = 0, what leads to an error");
            }

            double sqrtPart = SqrtHelp::CalculateSquareRoot(24 + D);
            double denominator = sqrtPart - C + (A / B);

            if (denominator == 0) {
                throw std::runtime_error("Denominator equals zero. Division by zero is impossible");
            }

            return denominator;
        }
        catch (const std::out_of_range& ex) {
            throw std::logic_error(std::string("Unresolved expression that led to an error in denominator: ") + ex.what());
        }
    }
};