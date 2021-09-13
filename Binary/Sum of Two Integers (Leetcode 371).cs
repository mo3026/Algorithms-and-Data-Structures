using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //https://learn.digilentinc.com/Documents/281
        //https://www.youtube.com/watch?v=YdaG_03fQ6E
        static int addOne(int num)
        {
            if (num == -1) return 0;
            int position = 1;
            while ((num & position) == position)
            {
                num = num ^ position;
                position <<= 1;
            }
            num = num ^ position;
            return num;
        }

        public static int addTwoComp(int a, int b)
        {
            if (a == 0) return b;
            int res = 0;
            int position = 1;
            int dig = a & position;
            while (dig == 0)
            {
                res |= dig ^ (b & position);
                position <<= 1;
                dig = a & position;
            }
            res |= dig ^ (b & position);
            if (a < 0 | addOne(~b) > a)
            {
                res |= addOne(~(position << 1));
            }
            return res;
        }

        public static int GetSum(int a, int b)
        {
            int res = 0;
            int position = 1;
            int brought = 0;
            int aa = a;
            int bb = b;
            if (a < 0) aa = addOne(~a);
            if (b < 0) bb = addOne(~b);
            int index = 0;
            while (index != 32)
            {
                int LSBofA = aa & position;
                if (a < 0) LSBofA = addOne(~LSBofA);
                int LSBofB = bb & position;
                if (b < 0) LSBofB = addOne(~LSBofB);
                int firstHalf = LSBofA ^ LSBofB;
                int secondHalf = firstHalf ^ brought;
                if (secondHalf != 0) res = addTwoComp(secondHalf, res);
                brought = (LSBofA & LSBofB) | (firstHalf & brought);
                brought = brought << 1;
                position <<= 1;
                index = addOne(index);
            }
            res = addTwoComp(brought, res);
            return (int)res;
        }
    }
}
