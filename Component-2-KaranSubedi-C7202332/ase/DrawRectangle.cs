using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component2
{
    /// <summary>
    /// Class create to draw rectangle and square
    /// </summary>
    class DrawRectangle : Shape
    {
        public int width;
        public int height;

        /// <summary>
        /// Default constructor for setting height and width
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public DrawRectangle(int width , int height) : base(width, height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Draw a rectangle or square according to user input
        /// </summary>
        /// <param name="newDrawing"></param>
        public override void draw(Drawing newDrawing)
        {
            newDrawing.g.DrawRectangle(newDrawing.p, newDrawing.xposition, newDrawing.yposition, width, height);

            if (newDrawing.fill)
            {
                newDrawing.g.FillRectangle(newDrawing.Brush, newDrawing.xposition,newDrawing.yposition,width,height);
            }
        }
    }
}
