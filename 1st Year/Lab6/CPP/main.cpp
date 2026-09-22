#include <iostream>
#include "Containter.h"
#include "Line.h"

int main() {
    Container* container = new Container();

    Line* line1 = new Line("First Beautiful Line");
    Line* line2 = new Line("Some Random text to fill the screen");
    Line* line3 = new Line("Suspicious 4th line");
    Line* line4 = new Line("Real 4th line, bwahahahhahah");
    Line* line5 = new Line("Who are you, the one, who's reading this ?");

    container->AddLine(line1);
    container->AddLine(line2);
    container->AddLine(line3);
    container->AddLine(line4);
    container->AddLine(line5);

    std::cout << "Start Text: " << std::endl;
    container->Print();

    char charToCount = 'l';
    double freq = container->GetCharFrequency(charToCount);
    std::cout << "Counting time: " << std::endl;
    std::cout << "How many l's: " << freq << std::endl;

    std::cout << "Replace Demo: " << std::endl;
    container->ReplaceString("4th", "5th");
    container->Print();

    std::cout << "Duplicate deleting demo: " << std::endl;
    container->FindDuplicate();
    container->Print();

    std::cout << "Line Remove Demo: " << std::endl;
    container->RemoveLine(line1);
    container->Print();

    std::cout << "Clear Demo: " << std::endl;
    container->Clear();

    delete line1;
    delete line2;
    delete line3;
    delete line4;
    delete line5;
    delete container;

    return 0;
}