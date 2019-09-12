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

        public static void Main()
        {
            var result = ArrayStrings.MyAtoi("2147483657");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
