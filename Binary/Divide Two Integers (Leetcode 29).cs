using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int Divide(int dividend, int divisor)
        {
            int i = 0;
            int dividendTemp;
            if (dividend > 0)
            {
                dividendTemp = ~dividend + 1;
            }
            else dividendTemp = dividend;
            int divisorTemp;
            if (divisor > 0)
            {
                divisorTemp = ~divisor + 1;
            }
            else divisorTemp = divisor;
            List<List<int>> powers = new List<List<int>>();
            int temp = divisorTemp;
            int power = -1;
            while (temp < 0 && dividendTemp <= temp)
            {
                powers.Add(new List<int> { temp, power });
                power <<= 1;
                temp <<= 1;
            }
            while (powers.Count > 0)
            {
                if (dividendTemp <= powers.Last()[0])
                {
                    i += (int)powers.Last()[1];
                    dividendTemp = dividendTemp - powers.Last()[0];
                    if (i == int.MinValue) break;
                }
                else
                {
                    powers.RemoveAt(powers.Count - 1);
                }
            }
            if (Math.Sign(dividend) == Math.Sign(divisor))
            {
                if (i == int.MinValue)
                {
                    return ~i;
                }
                else
                {
                    return -i;
                }
            }
            else
            {
                return i;
            }
        }
    }
}
