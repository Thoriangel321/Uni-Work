using Objects;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;

namespace ConsoleIO
{
    public class FileManagment
    {
        public void resetFile(string filename)
        {
            File.WriteAllText(filename + ".txt", "");
        }

        public void appendToFile(string filename, Person obj)
        {
            string record = "";

            if (obj is Student student)
            {
                record = $"Student {student.firstName}{student.lastName}\n" +
                         $"{{ \"firstname\": \"{student.firstName}\",\n" +
                         $"  \"lastname\": \"{student.lastName}\",\n" +
                         $"  \"studID\": \"{student.studID}\",\n" +
                         $"  \"height\": \"{student.height}\",\n" +
                         $"  \"weight\": \"{student.weight}\",\n" +
                         $"  \"passID\": \"{student.passID}\" }};\n";
            }
            else if (obj is Librarian librarian)
            {
                record = $"Librarian {librarian.firstName}{librarian.lastName}\n" +
                         $"{{ \"firstname\": \"{librarian.firstName}\",\n" +
                         $"  \"lastname\": \"{librarian.lastName}\" }};\n";
            }
            else if (obj is SoftwareDeveloper softDeveloper)
            {
                record = $"SoftwareDeveloper {softDeveloper.firstName}{softDeveloper.lastName}\n" +
                         $"{{ \"firstname\": \"{softDeveloper.firstName}\",\n" +
                         $"  \"lastname\": \"{softDeveloper.lastName}\" }};\n";
            }

            File.AppendAllText(filename + ".txt", record);
        }

        public string listFile(string filename)
        {
            if (File.Exists(filename + ".txt"))
            {
                return File.ReadAllText(filename + ".txt");
            }
            return "";
        }

        public string searchByLastName(string filename, string lastName)
        {
            if (!File.Exists(filename + ".txt")) return "";

            string[] lines = File.ReadAllLines(filename + ".txt");
            string result = "";
            bool isMatchingBlock = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(lastName) && !lines[i].Contains("\"lastname\""))
                {
                    isMatchingBlock = true;
                    result += lines[i] + "\n";
                }
                else if (isMatchingBlock)
                {
                    result += lines[i] + "\n";
                    if (lines[i].Contains("};"))
                    {
                        isMatchingBlock = false;
                    }
                }
            }
            return result;
        }
    }
}

