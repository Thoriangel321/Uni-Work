using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab3._2;

public class VectorCL : IComparable<VectorCL>
{
    public string color {get; set;}
    public double x {get; set;}
    public double y {get; set;}

    public double GetLength()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void AddLength(VectorCL vector, int a)
    {
        
    }

    public void DisplayInfo(VectorCL vector)
    {
        
    }

    public int CompareTo(VectorCL other) 
    {
        if (other == null) return 1;

        return this.GetLength().CompareTo(other.GetLength());
    }

    public override string ToString()
    {
        return $"Vector {color} (Length: {Math.Round(GetLength(), 2)})";
    }

    public VectorCL(string lineColor, double _x, double _y)
    {
        color = lineColor;
        x = _x;
        y = _y;
    }
}
