using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lab_3.Part1
{
    [Serializable]
    public class Vector : ISerializable
    {
        public string LineColor { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Vector() { }

        public Vector(string lineColor, double x, double y)
        {
            LineColor = lineColor;
            X = x;
            Y = y;
        }

        protected Vector(SerializationInfo info, StreamingContext context)
        {
            LineColor = info.GetString("Color");
            X = info.GetDouble("XCoord");
            Y = info.GetDouble("YCoord");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Color", LineColor);
            info.AddValue("XCoord", X);
            info.AddValue("YCoord", Y);
        }

        public double CalculateLength() => Math.Sqrt(X * X + Y * Y);

        public void IncreaseBySegment(double length)
        {
            double currentLength = CalculateLength();
            if (currentLength == 0) return;
            double ratio = (currentLength + length) / currentLength;
            X *= ratio;
            Y *= ratio;
        }

        public override string ToString() => $"Vector [Color: {LineColor}, X: {X:F2}, Y: {Y:F2}, Length: {CalculateLength():F2}]";
    }
}
