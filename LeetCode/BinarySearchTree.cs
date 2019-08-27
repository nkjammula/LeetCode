using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace LeetCode
{
    class BinarySearchTree
    {


        //static void Main(String[] args)
        //{
        //    Node root = null;
        //    Tree bst = new Tree();

        //    int Size = 3;

        //    int[] a = new int[7] { 8, 6, 4, 12, 45, 3, 5 };

        //    //Console.WriteLine("Generating random Array with size: " + Size);

        //    //Random rm = new Random();

        //    //Stopwatch sw = Stopwatch.StartNew();

        //    //for (int i = 0; i < Size; i++)
        //    //{
        //    //    a[i] = rm.Next(10000);
        //    //}

        //    //sw.Stop();

        //    //Console.WriteLine("Done. Took {0} seconds", (double)sw.ElapsedMilliseconds / 1000.0);
        //    //Console.WriteLine();
        //    //Console.WriteLine("Filling the tree with {0} nodes...", Size);

        //    //sw = Stopwatch.StartNew();

        //    //for (int i = 0; i < a.Length; i++)
        //    //{
        //    //    root = bst.Insert(root, a[i]);
        //    //}

        //    //sw.Stop();

        //    //Console.WriteLine("Done. Took {0} seconds", (double)sw.ElapsedMilliseconds / 1000.0);
        //    //Console.WriteLine();
        //    //Console.WriteLine("Traversing all {0} nodes in tree...", Size);

        //    //sw = Stopwatch.StartNew();
        //    //HashSet<int> HS = new HashSet<int>();
        //    //int a = 3;
        //    //string s = a.ToString();
        //    //char d = '4';
        //    //int c = int.Parse(d);
        //    //Interview intr = new Interview();
        //    //var sudoku = new char[][] { new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.' } ,
        //    //    new char[]{ '6', '.', '.', '1', '9', '5', '.', '.', '.' },
        //    //    new char [] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
        //    //     new char [] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
        //    //     new char [] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
        //    //      new char [] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
        //    //     new char [] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
        //    //     new char [] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
        //    //     new char [] { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
        //    //  Console.WriteLine(intr.IsValidSudoku(sudoku));
        //    Console.WriteLine("aAAbbbb" - "aA");
        // //   intr.GroupShiftedStrings(new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" });
        //    //Console.WriteLine(intr.TwoSum(new int[] { 2, 7, 11, 15 }, 9));
        //    //Console.WriteLine(intr.isIsoMorphic("ab", "ca"));
        //    //intr.FindRestaurant( new string[] {"k", "KFC"}, new string[] {"k", "KFC"});

        //    //Console.WriteLine(intr.FindRestaurant(new string[] {"Shogun", "Tapioca Express", "Burger King", "KFC" }, new string[] {"KFC", "Burger King", "Tapioca Express", "Shogun"}).ToString());
        //    //intr.FirstUniqChar("leetcode");

        //    //Console.WriteLine(intr.solution(new int[] {-1,-2,1,3}));
        //    //bst.Traverse(root);

        //    //sw.Stop();

        //    //Console.WriteLine("Done. Took {0} seconds", (double)sw.ElapsedMilliseconds / 1000.0);
        //    //Console.WriteLine();

        //    //bst.preOrderRecursive(root);

        //    Console.ReadKey();


        //}
    }

    class Tree
    {
        public Node Insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = Insert(root.left, v);
            }
            else
            {
                root.right = Insert(root.right, v);
            }
            return root;
        }

        public void Traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            Traverse(root.left);
            Traverse(root.right);
        }

        public void preOrderRecursive(Node root)
        {
            IList<int> IL = new List<int>();
            LinkedList<Node> stack = new LinkedList<Node>();
            Console.WriteLine(root.value.ToString());
            if (root.left != null)
            {
                preOrderRecursive(root.left);
            }
            if (root.right != null)
            {
                preOrderRecursive(root.right);
            }
        }
    }



    class Node
    {

        public int value;
        public Node left;
        public Node right;
    }

    class Interview
    {
            public bool IsValidSudoku(char[][] board)
            {
                HashSet<int> Row = new HashSet<int>();
                HashSet<int> Col = new HashSet<int>();
                HashSet<int> sub = new HashSet<int>();
                //char[][] SudokuArr = char int[9][];
                for(int i=0; i<board.Length; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j] != '.' && (int)board[i][j] <=9 && Row.Contains((int)board[i][j])){
                            return false;
                        }
                        else
                        {
                            Row.Add(board[i][j]);
                        }

                        if (board[j][i] != '.' && (int)board[j][i] <= 9 && Col.Contains(board[j][i]))
                        {
                            return false;
                        }
                        else
                        {
                            Col.Add(board[j][i]);
                        }

                        var x = (i % 3) * 3 + j % 3;
                        var y = (i / 3) * 3 + j / 3;
                        if (board[x][y] != '.' && sub.Contains(board[x][y])) return false;
                        sub.Add(board[x][y]);
                    }
                }
                return true;
            }
        public IList<IList<string>> GroupShiftedStrings(string[] strings)
        {
            Dictionary<string, List<string>> DIC = new Dictionary<string, List<string>>();
            foreach (var s in strings)
            {
                StringBuilder hashkey = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == 0)
                    {
                        hashkey.Append(s[i] - s[i]);
                    }
                    else
                    {
                        hashkey.Append((s[i] - s[i - 1]) < 0 ? (s[i] - s[i - 1]) + 26 : (s[i] - s[i - 1]));
                    }
                }
                string val = hashkey.ToString();
                if (DIC.ContainsKey(val))
                {
                    DIC[val].Add(s);
                }
                else
                {
                    DIC.Add(val, new List<string>() { s });
                }
            }
            return new List<IList<string>>(DIC.Values);
        }
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<int, List<string>> DIC = new Dictionary<int, List<string>>();
            foreach (var s in strings)
            {
                if (DIC.ContainsKey(s.Length))
                {
                    DIC[s.Length].Add(s);
                }
                else
                {
                    DIC.Add(s.Length, new List<string>() { s });
                }
            }
            return new List<IList<string>>(DIC.Values);
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {

            Dictionary<string, List<string>> DIC = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var sortedString = String.Concat(str.OrderBy(c => c));
                if (DIC.ContainsKey(sortedString))
                {
                    DIC[sortedString].Add(str);
                }
                else
                {
                    DIC.Add(sortedString, new List<string>() { str});
                }
            }

            return (new List<IList<string>>( DIC.Values) );
        }
        public bool IsHappy(int n)
        {
            HashSet<int> seen = new HashSet<int>();
            while (n != 1)
            {
                if (seen.Contains(n))
                    return false;
                seen.Add(n);
                int newnum = 0;
                while (n > 0)
                {
                    newnum += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }
                n = newnum;
            }
            return true;
        }

        public int[] TwoSum( int[] Arr, int target)
        {
            IDictionary<int, int> DIC = new Dictionary<int, int>();
            for(int i=0; i< Arr.Length; i++)
            {
                if(DIC.ContainsKey(target - Arr[i]))
                {
                    return new int[] { i, target - Arr[i] };
                }
                else
                {
                    if (!DIC.ContainsKey(Arr[i]))
                    {
                        DIC.Add(Arr[i], i);
                    }
                }
            }
            throw new Exception("no number");



            //Hashtable HTS = new Hashtable();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var complement = target - nums[i];
            //    if (HTS.ContainsKey(complement))
            //    {
            //        return new int[]
            //        {
            //            i,
            //            (int)HTS[complement]
            //        };
            //    }
            //    if (!HTS.ContainsKey(nums[i]))
            //    {
            //        HTS.Add(nums[i], i);
            //    }
            //}


            //throw new Exception("No two sum solution");
        }


        public bool isIsoMorphic(string s, string t)
        {
            IDictionary<char, char> DIC = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!DIC.ContainsKey(s[i]))
                {
                    if ((DIC.ContainsKey(t[i]) && DIC[t[i]] == t[i]))
                    {
                        return false;
                    }
                    DIC.Add(s[i], t[i]);
                }
                else
                {
                    if (DIC[s[i]] != t[i] )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            Hashtable HT = new Hashtable();
            Hashtable finalResult = new Hashtable();
            List<string> result = new List<string>();

            for (int i = 0; i < list1.Length; i++)
            {
                HT.Add(list1[i], i);
            }

            for (int i = 0; i <list2.Length; i++)
            {
                if (HT.ContainsKey(list2[i]))
                {
                    finalResult.Add(list2[i], i + (int)HT[list2[i]]);
                }
            }
            int minVal = int.MaxValue;
            foreach (DictionaryEntry item in finalResult)
            {
                if((int)item.Value <= minVal)
                {
                    if ((int)item.Value == minVal)
                    {
                        result.Add(item.Key.ToString());
                    }
                    else
                    {
                        result.Clear();
                        result.Add(item.Key.ToString());
                        minVal = (int)item.Value;
                    }
                }
            }
            return result.ToArray();
        }

        //public int FirstUniqChar(string s)
        //{
        //    Dictionary<char, int> DIC = new Dictionary<char, int>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        DIC.Add(s[i], i);
        //    }

           

        //}


            public int solution(int[] Arr)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < Arr.Length; i++)
            {
                if (!hs.Contains(Arr[i]))
                {
                    hs.Add(Arr[i]);
                }
            }

            for (int i = 0; i < Arr.Length; i++)
            {
                if (!hs.Contains(i+1))
                {
                    return i+1;
                }
            }

            return -1;
        }

        public int FirstUniqChar(string s)
        {
            var freq = new int[26];
            foreach (var c in s) freq[c - 'a']++;
            for (var i = 0; i < s.Length; i++)
            {
                if (freq[s[i] - 'a'] == 1) return i;
            }
            return -1;
        }
        public bool FindCharWithInIndex(string str, char target, char source, int distance)
        {
            int targetIndex = -1;
            int sourceIndex = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == source)
                {
                    sourceIndex = i;
                }
                if (str[i] == target)
                {
                    targetIndex = i;
                }

                if ((sourceIndex != -1 && targetIndex !=-1) )
                {
                    var number = (sourceIndex - targetIndex) < 0 ? (sourceIndex - targetIndex) * -1 : (sourceIndex - targetIndex);
                    if (number <= distance)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
