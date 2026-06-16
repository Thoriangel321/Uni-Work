using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Practics
{
    internal class Node
    {
        public Employee Data { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }

        public Node(Employee data) => Data = data;
    }
}
