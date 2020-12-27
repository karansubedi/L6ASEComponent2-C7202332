using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component2
{
    /// <summary>
    /// Class to create a triangle
    /// </summary>
    class DrawTriangle : Shape
    {
        public int hypotenuse;
        public int baseside;
        public int adjacent;

        public DrawTriangle(int h , int b, int a): base(h, b)
        {
            this.hypotenuse = h;
            this.baseside = b;
            this.adjacent = a;
        }

        public override void draw(Drawing newDrawing)
        {
            PointF h = new Point(newDrawing.xposition, newDrawing.yposition);
            PointF b = new Point(newDrawing.xposition + baseside, newDrawing.yposition);
            PointF a = new Point(newDrawing.xposition + baseside, newDrawing.yposition + adjacent);
            PointF[] point = { h, b, a };
            newDrawing.g.DrawPolygon(newDrawing.p, point);
            
            if (newDrawing.fill)
            {
                newDrawing.g.FillPolygon(newDrawing.Brush, point);
            }
        }
    }
}
