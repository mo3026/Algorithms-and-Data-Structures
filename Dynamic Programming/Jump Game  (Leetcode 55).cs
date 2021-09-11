using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static bool CanJump(int[] nums)
        {
            bool[] can = new bool[nums.Length];
            can[nums.Length - 1] = true;
            for (int i = can.Length - 2; i >= 0; i--)
            {
                for (int j = 1; j <= nums[i]; j++)
                {
                    if (i + j < nums.Length)
                    {
                        if (can[i + j])
                        {
                            can[i] = true;
                            break;
                        }
                    }
                    else break;
                }
            }
            return can[0];
        }
    }
}
