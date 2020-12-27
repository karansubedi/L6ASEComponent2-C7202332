using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Component2
{

    /// <summary>
    /// Drawing class to help data displayed in the form
    /// </summary>
    public class Drawing
    {
        /// <summary>
        /// Pen position instance
        /// Graphical context instance
        /// Brush Context instance
        /// Pen Context instance
        /// </summary>
        public Graphics g;
        public commandCheck commandCheck;
        public Pen p;
        public SolidBrush Brush;
        public int xposition;
        public int yposition;
        public bool fill = false;
        public bool error = false;
        public Variable v;
        public methods m;

        /// <summary>
        /// Initializing using constructors
        /// </summary>
        /// <param name="g"></param>
        public Drawing(Graphics g)
        {
            this.g = g;
            v = new Variable();
            m = new methods();
            commandCheck = new commandCheck();
            xposition = yposition = 0;
            p = new Pen(Color.Black, 1);
            Brush = new SolidBrush(Color.Black);
            
        }

        /// <summary>
        /// Set pen coordinates to move to a particular spot
        /// </summary>
        /// <param name="xpoint"></param>
        /// <param name="ypoint"></param>
        public void moveTo(int xpoint , int ypoint)
        {
            xposition = xpoint;
            yposition = ypoint;
        }
       

        /// <summary>
        /// Method to fill pen color
        /// </summary>
        /// <param name="fill"></param>
        public void set_penColor(Color c)
        {
            p = new Pen(c, 1);
            Brush = new SolidBrush(c);
        }

        /// <summary>
        /// Draw to command used to drawline from-to user given points
        /// </summary>
        /// <param name="xposition"></param>
        /// <param name="yposition"></param>
        public void drawTo(int xposition , int yposition)
        {
            g.DrawLine(p, this.xposition, this.yposition, xposition, yposition);
        }

        /// <summary>
        /// method created to reset the values
        /// </summary>
        public void reset()
        {
            xposition = yposition = 0;
            p = new Pen(Color.Black, 1);
            fill = false;
            error = false;
            g.Clear(SystemColors.Control);
        }

        /// <summary>
        /// Clears the picture box
        /// </summary>
        public void clear()
        {
            g.Clear(SystemColors.Control);
        }

    }
}
