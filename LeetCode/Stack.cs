using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class StackPrac
    {
        public static void Main(String[] args)
        {
            //Stack st = new Stack();
            //st.Push(1);
            //st.Push(5);
            //st.Push(10);

            //Console.WriteLine("Peek:" + st.Peek());

            //Console.WriteLine("Pop:" + st.Pop());

            //foreach (var item in st)
            //{
            //    Console.WriteLine(item);
            //}

            StackPrac sp = new StackPrac();
            //sp.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
            //sp.EvalRPN(new string[] { "2", "1", "+", "3", "*" });

            sp.decodeString("325[a]2[bc]");

            Console.ReadLine();
        }




        public int[] DailyTemperatures(int[] T)
        {
            //         int[] res = new int[T.Length];

            //         for(int i=0; i<T.Length; i++){

            //             for(int j= i+1; j<T.Length; j++){
            //                 if(T[j] > T[i]){
            //                     res[i] = j - i;
            //                     break;
            //                 }
            //             }
            //         }

            // return res;

            Stack stack = new Stack();
            int[] ret = new int[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count > 0 && T[i] > T[(int)stack.Peek()])
                {
                    int idx = (int)stack.Pop();
                    ret[idx] = i - idx;
                }
                stack.Push(i);
            }
            return ret;

        }

        public int EvalRPN(string[] tokens)
        {
            Stack st = new Stack();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+")
                {
                    int a = (int)st.Pop();
                    int b = (int)st.Pop();
                    st.Push(b + a);
                }
                else if (tokens[i] == "*")
                {
                    int a = (int)st.Pop();
                    int b = (int)st.Pop();
                    st.Push(b * a);
                }
                else if (tokens[i] == "-")
                {
                    int a = (int)st.Pop();
                    int b = (int)st.Pop();
                    st.Push(b - a);
                }
                else if (tokens[i] == "/")
                {
                    int a = (int)st.Pop();
                    int b = (int)st.Pop();
                    st.Push(b / a);
                }
                st.Push(int.Parse(tokens[i]));

            }
            return (int)st.Pop();
        }


        public String decodeString(string s)
        {
            String res = "";
            Stack countStack = new Stack();
            Stack resStack = new Stack();
            int idx = 0;
            while (idx < s.Length)
            {
                if (Char.IsDigit(s[idx]))
                {
                    int count = 0;
                    while (Char.IsDigit(s[idx]))
                    {
                        count = 10 * count + (s[idx] - '0');
                        idx++;
                    }
                    countStack.Push(count);
                }
                else if (s[idx] == '[')
                {
                    resStack.Push(res);
                    res = "";
                    idx++;
                }
                else if (s[idx] == ']')
                {
                    StringBuilder temp = new StringBuilder((string)resStack.Pop());
                    int repeatTimes = (int)countStack.Pop();
                    for (int i = 0; i < repeatTimes; i++)
                    {
                        temp.Append(res);
                    }
                    res = temp.ToString();
                    idx++;
                }
                else
                {
                    res += s[idx++];
                }
            }
            return res;
        }

        // "3[a]2[bc]"
//        s = "3[a2[c]]", return "accaccacc".
//s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
        public string DecodeStr(string s)
        {
            Stack countS = new Stack();
            Stack charS = new Stack();
            StringBuilder sb = new StringBuilder();
            string res="";
            int i = 0;
            while (i < s.Length)
            {
                if (Char.IsDigit(s[i]))
                {
                    countS.Push((int)s[i]);
                    i++;
                }
                else if(s[i] == '[')
                {
                    charS.Push(res);
                    res = "";
                    i++;
                }
                else if(s[i] == ']')
                {
                    string elm = charS.Pop().ToString();
                    for(int j=0; j<=(int)countS.Pop(); j++)
                    {
                        sb.Append(elm);
                    }
                    res = sb.ToString();
                    i++;
                }
                else
                {
                    res = res + s[i];
                }
            }
            return res;
        }
        //     public void DFS(char[][] grid, int r, int c){
        //         int rc = grid.Length;
        //         int cc = grid[0].Length;
        //         if(c<0 || r<0 || r>=rc || c>=cc || grid[r][c] == '0'){
        //             return;
        //         }

        //         grid[r][c] = '0';
        //         DFS(grid,r-1,c);
        //         DFS(grid,r+1,c);
        //         DFS(grid, r,c-1);
        //         DFS(grid,r,c+1);
        //     }
        //     public int NumIslands(char[][] grid) {
        //         if(grid.Length == 0 || grid == null){
        //             return 0;
        //         }
        //       int rc = grid.Length;
        //         int cc = grid[0].Length;
        //         for(int r =0; r<rc; r++){
        //             for(int c=0; c<cc; c++){
        //                 if(grid[r][c] == '1'){
        //                     ++islands;
        //                     DFS(grid, r,c);
        //                 }
        //             }
        //         }
        //         return islands;
        //     }

    }
}
