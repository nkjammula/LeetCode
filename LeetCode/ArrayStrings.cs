using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace LeetCode
{
    class ArrayStrings
    {
        public static int MyAtoi(string str)
        {
            int index = 0, sign = 1, total = 0;

            //1. Remove Spaces
            str = str.Trim();

            //2. Check for Empty string
            if (str.Length == 0) return 0;

            //3. Handle signs
            if (str[index] == '+' || str[index] == '-')
            {
                sign = str[index] == '+' ? 1 : -1;
                index++;
            }

            //4. Convert number and avoid overflow
            while (index < str.Length)
            {
                int digit = str[index] - '0';
                if (digit < 0 || digit > 9) break;

                //check if total will be overflow after 10 times and add digit
                if (total > Int32.MaxValue / 10 || ( Int32.MaxValue / 10 == total && Int32.MaxValue % 10 < digit))
                    return sign == 1 ? Int32.MaxValue : Int32.MinValue;

                total = 10 * total + digit;
                index++;
            }
            return total * sign;
        }

        public string IntToRoman(int num)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<int, string> DIC = new Dictionary<int, string>{
         {1000,"M"},
         {900,"CM"},
          {500, "D"},
           {400,"CD"},
            {100,"C"},
         {90,"XC"},
         {50,"L"},
         {40,"XL"},
         {10,"X"},
         {9,"IX"},
         {5,"V"},
         {4, "IV"},
         {1,"I"}
     };

            foreach (var dic in DIC)
            {
                while (num >= dic.Key)
                {
                    num = num - dic.Key;
                    result.Append(dic.Value);
                }

            }
            return result.ToString();
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int result = 0;
            int[] index = new int[128];

            for (int i = 0, j = 0; j < n; j++)
            {
                i = Math.Max(index[s[j]], i);
                result = Math.Max(result, j - i + 1);
                index[s[j]] = j + 1;
            }
            return result;
        }

        public static int[] PlusOne(int[] digits)
        {
            int[] result = new int[digits.Length + 1];
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i] += 1;
                    return digits;
                }
                digits[i] = 0;
            }
            result[0] = 1;
            return result;
        }


        public static bool solution(int[] A, int K)
        {  //1 1 2 3 3
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] + 1 < A[i + 1])
                    return false;
            }

            if ((A[0] != 1 && A[n - 1] != K) || ((K > A[n - 1]) || K < A[0]))
                return false;

           
            else
                return true;
        }


        public static void Main()
        {
            // var result = ArrayStrings.MyAtoi("2147483657");
            // var result = ArrayStrings.LengthOfLongestSubstring("abcabcbb");
            //var ts = new TwoSum();
            //ts.Add(0);
            //ts.Add(-1);
            //ts.Add(-1);
            //ts.Add(0);
            //ArrayStrings.PlusOne(new int[] { 8, 9 });
            //ArrayStrings.solution(new int[] { 1,1,2,3,3 }, 3);

            //Console.WriteLine(ArrayStrings.solution(new int[] { 1, 1, 2, 3, 3 }, 4));
            Console.WriteLine(TwoSum.ReturnAvgOfWindowSize(new int[] { 2,4,6,8}, 4));
            Console.ReadLine();
        }
    }

    public class TwoSum
    {

        Dictionary<int, int> dict = new Dictionary<int, int>();

        // Add the number to an internal data structure.
        public void Add(int number)
        {
            if (!dict.ContainsKey(number)) dict[number] = 1;
            else dict[number] = 2;
        }

        // Find if there exists any pair of numbers which sum is equal to the value.
        public bool Find(int value)
        {
            foreach (int key in dict.Keys)
            {
                if (key == value - key)
                {
                    if (dict[key] == 2) return true;
                }
                else
                    if (dict.ContainsKey(value - key)) return true;
            }

            return false;
        }


        public static ArrayList ReturnAvgOfWindowSize(int[] inputArr, int windowSize)
        {
            ArrayList outPut = new ArrayList();
            for (int i = 0; i <= inputArr.Length-1; i++)
            {
                int sum = 0;
                if(i+windowSize-1 >= inputArr.Length)
                {
                    return outPut;
                }
                for (int j = i; j <= i+ windowSize -1; j++)
                {
                    sum += inputArr[j];
                }
                outPut.Add(sum / windowSize);
            }

            return outPut;
        }
    }
}
