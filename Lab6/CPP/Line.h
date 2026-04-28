#pragma once
#include <string>

class Line {
public:
    std::string str = "";

    Line() {
    }

    Line(std::string coolString) {
        str = coolString;
    }

    int FindRate(char c) {
        int a = 0;
        for (size_t i = 0; i < str.length(); i++) {
            if (str[i] == c) a++;
        }
        return a;
    }

    int GetLength() {
        return str.length();
    }

    void Replace(std::string oldStr, std::string newStr) {
        size_t pos = 0;
        while ((pos = str.find(oldStr, pos)) != std::string::npos) {
            str.replace(pos, oldStr.length(), newStr);
            pos += newStr.length();
        }
    }

    bool isEqualTo(Line* other) {
        return this->str == other->str;
    }

    std::string ToString() {
        return str;
    }
};