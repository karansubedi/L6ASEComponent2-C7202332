using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component2
{
    /// <summary>
    /// Class created to store methods provided by users
    /// </summary>
   public class methods
    {
        Dictionary<string, string> method = new Dictionary<string, string>();

        /// <summary>
        /// To store method and their purpose
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void storeMethod(String name, string value)
        {
            method.Add(name, value);            
        }

        /// <summary>
        /// Get the methods stored
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string getMethod(String name)
        {
            string n;
            method.TryGetValue(name, out n);
            return n;
        }

        /// <summary>
        /// Method to check existing method in the dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool existingMethod(String name)
        {
            string n;
            return method.TryGetValue(name , out n);
        }

        /// <summary>
        /// Resets the method dictionary
        /// </summary>
        public void reset()
        {
            method.Clear();
        }

    }
}
