using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component2
{
    /// <summary>
    /// Variable class is used to get instruction given by users
    /// </summary>
   public class Variable
    {
        Dictionary<string, int> variable = new Dictionary<string, int>();
        
        /// <summary>
        /// Store variables provided by user and their values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void storeData(String name , int value)
        {
            variable.Add(name, value);
        }

        /// <summary>
        /// To get the user enterd data
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int pullData(String name)
        {
            int x;
            variable.TryGetValue(name, out x);
            return x;
        }


        /// <summary>
        /// To check whether the variable exists or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool exisitingVariable(String name)
        {
            int x;
            return variable.TryGetValue(name, out x);
        }


        /// <summary>
        /// TO update the variable
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void UpdateVariable(String name , int value)
        {
            variable[name] = value;
        }

        /// <summary>
        /// To clear the variable dictionary
        /// </summary>
        public void reset()
        {
            variable.Clear();
        }

    }
}
