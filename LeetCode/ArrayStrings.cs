using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

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
           //Console.WriteLine(TwoSum.ReturnAvgOfWindowSize(new int[] { 2,4,6,8}, 4));
           //Console.WriteLine(TwoSum.addBinary("11","1"));
           //Console.WriteLine(TwoSum.addBinary("11","1"));
           //bool IsPrime = true;
           //Console.WriteLine("Prime numbers :");
           //for (int i = 2; i <= 100; i++)
           //{
           //    for (int j = 2; j < 100; j++)
           //    {
           //        if (i != j && i % j == 0)
           //        {
           //            IsPrime = false;
           //            break;
           //        }
           //    }
           //    if (IsPrime)
           //    {
           //        Console.Write("\t" + i);

           //    }
           //    IsPrime = true;
           //}
           //Console.ReadKey();

           //Console.WriteLine(TwoSum.StrStr("mississippi","issipi"));
           //TwoSum.ReverseString(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' });
           // TwoSum.MinSubArrayLen( 7, new int[] {2,3,1,2,4,3 });
           // TwoSum.reverseArray(new int[] { 1, 2, 3, 4, 5 });
           //TwoSum.ReverseArrByNothalfLength(new int[] { 1, 2, 3, 4, 5 });
           //TwoSum.ReverseWordsInString();
           //TwoSum.RemoveDuplicates(new int[] { 1,2,3,4,4,5});
           TwoSum ts = new TwoSum();
           //ts.numIslands(new char[][] { new char[] {'1','1','1','1','0' },
           //                new char[] { '1', '1', '0', '1', '0' },
           // new char[] {'1','1','0','0','0' },
           // new char[] {'0','0','0','0','0' }});
           //ts.NumSquares(12);
           //ts.returnSetNumbers(new int[] { 2,4,6,10}, 16);
           //ts.returnSetNumbers(new int[] { 11,10,4,2,6}, 16);
           //ts.returnSetNumbers(new int[] {1,2,3,4,5}, 8);
          // ts.returnSetNumbers(new int[] {1,2,3,4,5,6,7,8,9,10,0}, 10);
          
           Console.WriteLine(ts.LongestRepeatingLength());
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


        public static String addBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int i = a.Length - 1, j = b.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (j >= 0) sum += b[j--] - '0';
                if (i >= 0) sum += a[i--] - '0';

                sb.Append(sum % 2);
                carry = sum / 2;
            }
            if (carry != 0) sb.Append(carry);
            return new string(sb.ToString().Reverse().ToArray());
        }

        public static int StrStr(string haystack, string needle)
        {

            int ans = -1;

            if (String.IsNullOrEmpty(needle))
            {
                return 0;
            }

            int TrueCounter = 0;

            for (int i = 0; i < haystack.Length; i++)
            {

                int j = i;
                int needleIt = 0;

                if (TrueCounter == needle.Length)
                {
                    return ans;
                }
                TrueCounter = 0;
                while (j <= i + needle.Length - 1 && i + needle.Length - 1 <= haystack.Length - 1)
                {
                    if (haystack[j] == needle[needleIt])
                    {
                        if (needleIt == 0)
                        {
                            ans = i;
                        }
                        TrueCounter++;
                    }
                    j++;
                    needleIt++;
                }
            }
            return ans;
        }

        public static void ReverseString(char[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char buffer = ' ';

                if (i == s.Length - 1 - i)
                {
                    break;
                }
                buffer = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = buffer;

                if((s.Length - 1 - i) -1 == 1)
                {
                    break;
                }
            }

        }

        public static int MinSubArrayLen(int s, int[] nums)
        {
            int n = nums.Length;
            int ans = int.MaxValue;
            int left = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                while (sum >= s)
                {
                    ans = Math.Min(ans, i + 1 - left);
                    sum -= nums[left++];
                }
            }
            return (ans != int.MaxValue) ? ans : 0;

        }

        public static void reverseArray(int[] a)
        {
            for(int i=0; i<a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            for(int i=0; i<a.Length/2; i++)
            {
                int temp = a[i];
                a[i] = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = temp;
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        public static void ReverseArrByNothalfLength(int [] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            int start = 0;
            int end = a.Length-1;
            while( start < end)
            {
                int temp = a[start];
                a[start] = a[end];
                a[end] = temp;
                start++;
                end--;
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        /*Input: "the sky is blue"
        Output: "blue is sky the"
        
             */
        public static void ReverseWordsInString(string s = "the sky   is blue  ")
        {
           char[] c =s.ToCharArray();
            StringBuilder sb = new StringBuilder();
            reverse(c, 0, c.Length - 1);
            int start = 0;
            int end = s.Length - 1;
            for (int i = 0; i < s.Length; i++) //reverse each word
            {
                if (c[i] == ' ')
                {
                    reverse(c, start, i - 1);
                    start = i + 1;
                }
            }
            reverse(c, start, end); //reverse the last word
            //for(int i =0; i<sb.Length; i++)
            //{
            //    if(res.Length == 0 && sb[i] == ' ')
            //    {
            //        continue;
            //    }
            //    if(sb[i])
            //    else
            //    {
            //        res.Append(sb[i]);
            //    }
            //}
            Console.WriteLine(c);

        }

        public static void reverse(char[] s, int start, int end)
        {
            while (start < end)
            {
                char temp = s[start];
                s[start] = s[end];
                s[end] = temp;
                start++;
                end--;
            }
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                }
                nums[i] = nums[j];

            }
            return i + 1;
        }

        void dfs(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        public int numIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r][c] == '1')
                    {
                        ++num_islands;
                        dfs(grid, r, c);
                    }
                }
            }

            return num_islands;
        }


        public int NumSquares(int n)
        {
            var dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[0] = int.MaxValue;
            }
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }

        public int returnSetNumbers(int[] input, int num)
        {
            int counter=0;
            for(int i= input.Length -1; i >= 0; i--)
            {
                int sum = input[i];
                for(int j=i-1; j>=0; j--)
                {
                    sum += input[j];
                    if(sum == num)
                    {
                        counter++;
                        sum = sum - input[j];
                        continue;
                    }
                    if(input[i] + input[j] == num)
                    {
                        counter++;
                    }
                    if(sum > num)
                    {
                        sum = sum - input[j];
                    }
                }
            }
            return counter;
        }

        public int LongestRepeatingLength(){
        int[] nums = new int[]{0,1,1,0,1,1,0,1,1,1,1};
        int max=0;
        int temp =0;
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 1){
                temp++;
                max = Math.Max(max,temp);
            }
            else{
                temp = 0;
            }
        }
        return max;
        }
        ///*Hello*/
        //public static PascalTriangle(int a)
        //{
        //    List<List<int>> triangle = new List<List<int>>();
        //    triangle.Add(new List<int>() { 1 });

        //    for (int i = 1; i <= a; i++)
        //    {
        //        List<int> node = new List<int>();
        //        node.Add(1);
        //        List<int> preNode = triangle[i - 1];
        //        int k = 0;
        //        while (k <= preNode.Count)
        //        {
        //            int sum = preNode[k - 1] + preNode[k];
        //            node.Add(sum);
        //        }
        //        node.Add(1);
        //        triangle.Add(node);
        //    }

        //}
    }
}
