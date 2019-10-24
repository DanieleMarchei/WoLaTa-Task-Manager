using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoLaTa_Task_Manager.Utils
{
    /// <summary>
    /// Class with useful math functions
    /// </summary>
    public static class MathUtilities
    {
        /// <summary>
        /// Constrains a <i>number</i> to be in between <i>min</i> and <i>max</i> (included)
        /// </summary>
        /// <param name="min">The lower bound</param>
        /// <param name="number">The number to be contrained</param>
        /// <param name="max">The upper bound</param>
        /// <returns>An integer between <i>min</i> and <i>max</i> (included)</returns>
        public static int Constrain(int min, int number, int max)
        {
            if (number < min) return min;

            if (number > max) return max;

            return number;

        }
    }
}
