using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.BLL.Models
{
    public class StudentModel
    {
        public string FullName { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string StudentCard { get; set; }

        public bool IsIdealWeight() => (Height - 110) == Weight;
    }
}
