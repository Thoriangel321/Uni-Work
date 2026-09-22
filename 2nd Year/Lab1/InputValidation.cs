using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleIO
{
    public class InputValidation
    {
        public string namePattern = @"^[A-Za-zА-Яа-яЄєІіЇїҐґ'-]+$";
        public string studIDpattern = @"^[A-Z]{2}\d{6}$";

        public bool isValidName(string input)
        {
            return Regex.IsMatch(input, namePattern);
        }

        public bool isValidStudID(string input)
        {
            return Regex.IsMatch(input, studIDpattern);
        }
    }
}
