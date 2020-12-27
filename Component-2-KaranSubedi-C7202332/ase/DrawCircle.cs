using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component2
{
    /// <summary>
    /// Class created to draw circle and regulate shapes
    /// </summary>
    public class DrawCircle : Shape
    {
        //radius to draw circle
        public int radius;

        /// <summary>
        /// Set the radius using constructor
        /// </summary>
        /// <param name="r"></param>
        public DrawCircle(int r) : base(r, 0)
        {
            this.radius = r;
        }

        /// <summary>
        /// Draws a circle on Drawing surface
        /// </summary>
        /// <param name="newDrawing"></param>
        public override void draw(Drawing newDrawing)
        {
            newDrawing.g.DrawEllipse(newDrawing.p, newDrawing.xposition, newDrawing.yposition, (radius * 2), (radius * 2));

            if (newDrawing.fill)
            {
                newDrawing.g.FillEllipse(newDrawing.Brush, newDrawing.xposition,newDrawing.yposition,(radius * 2), (radius * 2));
            }
        }

    }
}
