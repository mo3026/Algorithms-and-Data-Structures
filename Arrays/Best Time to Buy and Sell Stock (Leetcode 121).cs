using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            int min = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min) min = prices[i];
                else profit = Math.Max(profit, prices[i] - min);
            }
            return profit;
        }
    }
}
