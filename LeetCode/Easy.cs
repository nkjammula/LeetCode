using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Easy 
    {
        public int[] TwoSum(int[] nums, int target)
        {
            //Brute force
            //for (int x = 0; x < nums.Length; x++)
            //{
            //    for (int y = x + 1; y < nums.Length; y++)
            //    {
            //        if (nums[x] == target - nums[y])
            //        {
            //            return new int[] { x, y };
            //        }
            //    }
            //}

            //With two hash tables
            //Dictionary<int,int> DIC = new Dictionary<int, int>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    DIC.Add(nums[i], i);
            //}

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var complement = target - nums[i];
            //    if (DIC.ContainsKey(complement) && DIC.GetValueOrDefault(complement) != i)
            //    {
            //        return new int[] { i, DIC.GetValueOrDefault(complement) };
            //    }
            //}

            //With hash tables
            //Hashtable HT = new Hashtable();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    HT.Add(nums[i], i);
            //}

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var complement = target - nums[i];
            //    if(HT.ContainsKey(complement) && (int) HT[complement] != i)
            //    {
            //        return new int[] { i, (int)HT[complement] };
            //    }
            //}
           
            //With single hash table

            Hashtable HTS = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (HTS.ContainsKey(complement))
                {
                    return new int[]
                    {
                        i,
                        int.Parse(HTS[complement].ToString())
                    };
                }
                if (!HTS.ContainsKey(nums[i]))
                {
                    HTS.Add(nums[i], i);
                }
            }
           

            throw new Exception("No two sum solution");
        }

    }
}
