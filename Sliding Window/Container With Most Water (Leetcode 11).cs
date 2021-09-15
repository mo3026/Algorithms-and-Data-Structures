using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MaxArea(int[] height)
        {
            int maxLeft = 0;
            int maxRight = height.Length - 1;
            int MaxArea = (maxRight - maxLeft) * (Math.Min(height[maxRight], height[maxLeft]));
            while (maxRight != maxLeft)
            {
                if (maxLeft < maxRight)
                {
                    maxLeft = maxLeft + 1;
                    int temp = (maxRight - maxLeft) * (Math.Min(height[maxRight], height[maxLeft]));
                    if (temp > MaxArea) MaxArea = temp;
                }
                else
                {
                    maxRight = maxRight - 1;
                    int temp = (maxLeft - maxRight) * (Math.Min(height[maxRight], height[maxRight]));
                    if (temp > MaxArea) MaxArea = temp;
                }
            }
            return MaxArea;
        }
    }
}
