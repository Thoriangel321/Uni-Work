using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DAL.Entities
{
    [Serializable]
    public class StudentEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string StudentCard { get; set; }
        public string Passport { get; set; }
    }
}
