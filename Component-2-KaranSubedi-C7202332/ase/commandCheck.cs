using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Component2
{
    /// <summary>
    /// Class created for checking commands for errors and exception handling
    /// </summary>
    public class commandCheck
    {
        
        /// <summary>
        /// method to display error when entered command doesn't exist
        /// </summary>
        /// <param name="newDrawing"></param>
        /// <param name="n"></param>
        /// <param name="x"></param>
        public void Commands_Check(Drawing newDrawing,int n, int x)
        {
            //Instantiation for new font and brush to write errors

            Font Font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Red);
            n++;

            if(n != 0)
            {
                if(x == 0)
                {
                    newDrawing.reset();
                }
                newDrawing.g.DrawString("Command on line " + (n) + " doesn't exists", Font, brush, 0, 0 + x);

            }
            else
            {
                newDrawing.g.DrawString("Command doesn't exist ", Font, brush, 0, 0 + x);
            }
            newDrawing.error = true;
        }
        /// <summary>
        /// If parameters are invalid then error is displayed
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="data"></param>
        /// <param name="n"></param>
        /// <param name="newDrawing"></param>
        /// <param name="x"></param>
        public void Parameterscheck(bool parameter, String data, int n, Drawing newDrawing, int x)
        {


            if (!parameter)
            {
                Font Font = new Font("Arial", 10);
                SolidBrush brush = new SolidBrush(Color.Red);
                if (x == 0)
                {
                    newDrawing.reset();
                }
                if ((n + 1) == 0)
                {
                    newDrawing.g.DrawString("Invalid Parameters " + data, Font, brush, 0, 0 + x);
                }
                else
                {
                    newDrawing.g.DrawString("Parameter Invalid ", Font, brush, 0, 0 + x);
                }
                newDrawing.error = true;
            }
        }
        /// <summary>
        /// Method to check number of parameters entered and display error if not
        /// </summary>
        /// <param name="e"></param>
        /// <param name="newDrawing"></param>
        /// <param name="count"></param>
        /// <param name="x"></param>
        public void Parameterscheck(Exception e, Drawing newDrawing , int n , int x)
        {
            Font Font = new Font("TimesNewRoman", 10);
            SolidBrush brush = new SolidBrush(Color.Red);
            if (x == 0)
            {
                newDrawing.reset();
            }
            if((n+1) == 0)
            {
                newDrawing.g.DrawString("Wrong number of Parameters ", Font, brush, 0, 0 + x);
            }
            else
            {
                newDrawing.g.DrawString("Wrong number of Parameters inserted "+ (n+1), Font, brush, 0, 0 + x);
            }

            newDrawing.error = true;
        }
    }


    
}
