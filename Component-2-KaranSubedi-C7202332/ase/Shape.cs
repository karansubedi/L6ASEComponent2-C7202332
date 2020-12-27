using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component2
{
    /// <summary>
    /// Class Created to help in drawing different shapes
    /// </summary>
    public abstract class Shape
    {

        //width and height to help get values
        int width;
        int height;


        /// <summary>
        /// Deault constructor to get values of width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Shape(int width , int height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract void draw(Drawing newDrawing);

    }
}
