using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoLaTa_Task_Manager.Extensions
{
    /// <summary>
    /// Class that adds methods to the List class
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Swaps two elements in the list
        /// </summary>
        /// <typeparam name="T">The type of the objects</typeparam>
        /// <param name="list">The list</param>
        /// <param name="t1">Index of the first element</param>
        /// <param name="t2">Index of the second element</param>
        public static void Swap<T>(this List<T> list, int t1, int t2)
        {
            T tmp = list[t1];
            list[t1] = list[t2];
            list[t2] = tmp;
        }
    }
}
