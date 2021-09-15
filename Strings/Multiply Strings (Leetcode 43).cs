using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static string Multiply(string num1, string num2)
        {
            StringBuilder sum = new StringBuilder("");
            for (int i = 0; i < num1.Length + num2.Length; i++) sum.Append("0");
            for (int i = num2.Length - 1; i >= 0; i--)
            {
                int y = 1;
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    int product = (num2[i] - '0') * (num1[j] - '0');
                    int tmp = sum[i + j + 1] - '0' + product;
                    sum[i + j + 1] = (char)((tmp % 10) + '0');
                    sum[i + j] = (char)((sum[i + j]) + tmp / 10);
                }
            }
            string result = sum.ToString().TrimStart(new Char[] { '0' });
            return result.Length > 0 ? result : "0";
        }
    }
}
