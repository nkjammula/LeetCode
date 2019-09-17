using System;
using System.Collections.Generic;
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

       



        public static void Main()
        {
           // var result = ArrayStrings.MyAtoi("2147483657");
           var result = ArrayStrings.LengthOfLongestSubstring("abcabcbb");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
