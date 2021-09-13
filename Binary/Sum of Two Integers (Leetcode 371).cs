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
        public static int addTwoComp(int a, int b)
        {
            if (a == 0) return b;
            int res = 0;
            int place = 1;
            int dig = a & place;
            while (dig == 0)
            {
                res |= dig ^ (b & place);
                place = place << 1;
                dig = a & place;
            }
            res |= dig ^ (b & place);
            if (a < 0)
            {
                res |= addOne(~(place << 1));
            }
            else
            {
                if (addOne(~b) > (a))
                {
                    res |= addOne(~(place << 1));
                }
            }
            return res;
        }

        static int addOne(int x)
        {
            if (x == -1) return 0;
            int m = 1;
            while ((x & m) == m)
            {
                x = x ^ m;
                m <<= 1;
            }
            x = x ^ m;
            return x;
        }

        public static int GetSum(int a, int b)
        {
            int res = 0;
            int place = 1;
            int brought = 0;
            int aa = a;
            int bb = b;
            if (a < 0) aa = addOne(~a);
            if (b < 0) bb = addOne(~b);
            int index = 0;
            while (index != 32)
            {
                int LSBofA = aa & place;
                if (a < 0) LSBofA = addOne(~LSBofA);
                int LSBofB = bb & place;
                if (b < 0) LSBofB = addOne(~LSBofB);
                int firstHalf = LSBofA ^ LSBofB;
                int secondHalf = firstHalf ^ brought;
                if (secondHalf != 0)
                    res = addTwoComp(secondHalf, res);

                brought = (LSBofA & LSBofB) | (firstHalf & brought);
                brought = brought << 1;
                place = place << 1;
                index = addOne(index);
            }
            res = addTwoComp(brought, res);
            return (int)res;
        }
    }
}
