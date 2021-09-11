using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;


namespace ConsoleApp2
{
    public class Program
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int[] buy = new int[prices.Length];
            int[] sell = new int[prices.Length];
            buy[0] = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                buy[i] = Math.Max(buy[i - 1], sell[i - 1] - prices[i]); // zarar
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i] - fee); //sood
            }
            return sell.Last();
        }
    }
}
