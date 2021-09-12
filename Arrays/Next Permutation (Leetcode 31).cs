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
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static void NextPermutation(int[] nums)
        {
            int i;
            for (i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1]) break;
            }
            if (i == -1)
            {
                Array.Reverse(nums);
                return;
            }
            int j = nums.Length - 1;
            while (nums[i] >= nums[j]) j--;
            if (j != i)
            {
                Swap(nums, i, j);
                Array.Sort(nums, i + 1, nums.Length - i - 1);
            }
            else
            {
                Swap(nums, j, i + 1);
            }
        }
    }
}
