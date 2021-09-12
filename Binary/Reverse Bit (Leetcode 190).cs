using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static uint reverseBits(uint n)
        {
            uint res = 0;
            for(int i=0;i<32; i++)
            {
                res <<= 1;
                res |= n & 1;
                n >>= 1;
            }
            return res;
        }
    }
}
