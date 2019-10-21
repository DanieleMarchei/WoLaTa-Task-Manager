using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoLaTa_Task_Manager.Extensions
{
    public static class MyMath
    {
        public static int Constrain(int min, int number, int max)
        {
            if (number < min) return min;

            if (number > max) return max;

            return number;

        }
    }
}
