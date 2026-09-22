#include "ExpressionEvaluator.h"
#include <iostream>
#include <vector>

int main() {
    std::vector<ExpressionEvaluator> evaluators = {
        ExpressionEvaluator(2, 4, 1, 1),
        ExpressionEvaluator(5, 0, 3, 12),
        ExpressionEvaluator(1, 2, 5, -30),
        ExpressionEvaluator(1, 1, 6, 1)
    };

    for (size_t i = 0; i < evaluators.size(); i++) {
        std::cout << "Parameters: " << evaluators[i].ToString() << "\n";

        try {
            double result = evaluators[i].Calculate();
            std::cout << "Result: " << result << "\n\n";
        }
        catch (const std::exception& ex) {
            std::cout << "Error, if Present: " << ex.what() << "\n\n";
        }
    }

    std::cin.get();
    return 0;
}