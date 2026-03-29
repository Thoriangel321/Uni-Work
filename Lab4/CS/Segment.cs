using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Segment : Lines
    {
        public Segment() 
        {

        }
        public Segment(double X1, double Y1, double X2, double Y2) : base(X1, Y1, X2, Y2)
        {
            x1d = X1;
            this.x1 = x1d;
            y1d = Y1;
            this.y1 = y1d;
            x2d = X2;
            this.x2 = x2d;
            y2d = Y2;
            this.y1 = y2d;
        }
        public Segment(Segment seg) 
        {
            x1d = seg.x1;
            this.x1 = x1d;
            y1d = seg.y1;
            this.y1 = y1d;
            x2d = seg.x2;
            this.x2 = x2d;
            y2d = seg.y2;
            this.y2 = y2d;
        }

        public Segment Extrude(Segment seg) 
        {
            seg.x1d = seg.x1d * 2;
            this.x1 = seg.x1d;
            seg.y1d = seg.y1d * 2;
            this.y1 = seg.y1d;
            seg.x2d = seg.x2d * 2;
            this.x2 = seg.x2d;
            seg.y2d = seg.y2d * 2;
            this.y2 = seg.y2d;
            return seg;
        }
    }
}
