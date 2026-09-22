using System;
using System.Collections.Generic;
using System.Text;

namespace Objects
{

    public abstract class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int experience { get; set; }
    }

    public class Student : Person
    {
        public int height { get; set; }
        public int weight { get; set; }
        public string studID { get; set; }
        public string passID { get; set; }

        public void Study()
        {
            experience += 10;
        }
    }

    public class Librarian : Person
    {
        public void Reading()
        {
            experience += 5;
        }
    }

    public class SoftwareDeveloper : Person
    {
        public void Develop()
        {
            experience += 20;
        }
    }
}
