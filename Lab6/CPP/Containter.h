#pragma once
#include <vector>
#include <string>
#include <iostream>
#include <algorithm>
#include "IDuplicate.h"
#include "Line.h"

class Container : public IDuplicate {
private:
    std::vector<Line*> lines;

public:
    Container() {
    }

    void AddLine(Line* line) {
        lines.push_back(line);
    }

    void RemoveLine(Line* line) {
        lines.erase(std::remove(lines.begin(), lines.end(), line), lines.end());
    }

    void Clear() {
        lines.clear();
    }

    double GetCharFrequency(char c) {
        int totalChars = 0;
        int targetChars = 0;

        for (Line* line : lines) {
            totalChars += line->GetLength();
            targetChars += line->FindRate(c);
        }

        return (double)totalChars / targetChars;
    }

    void ReplaceString(std::string Old, std::string New) {
        for (Line* line : lines) {
            line->Replace(Old, New);
        }
    }

    void Print() {
        for (Line* line : lines) {
            std::cout << line->ToString() << std::endl;
        }
    }

    void FindDuplicate() override {
        std::vector<Line*> uniqueLines;

        for (Line* currentLine : lines) {
            bool isDup = false;
            for (Line* unique : uniqueLines) {
                if (currentLine->isEqualTo(unique)) {
                    isDup = true;
                    break;
                }
            }

            if (!isDup) {
                uniqueLines.push_back(currentLine);
            }
        }

        lines = uniqueLines;
    }
};