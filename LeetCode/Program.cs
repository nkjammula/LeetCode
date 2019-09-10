using System;

namespace LeetCode
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //            Console.WriteLine("Enter Leet Code Porblem Title OR ID");
        //    //            var EasyObj = new Easy();
        //    //            var IndexArr = EasyObj.TwoSum(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }
        //    //, 542);
        //    //Arrays.arrays();
        //    //Arrays.FillArray();
        //    //Arrays.FillArraywithForEach();
        //    //Arrays.MultiDimensionalArrays();
        //    Arrays.JaggedArrays();
        //    Console.ReadLine();
        //}
    }


    class Arrays
    {
        public static void arrays()
        {
            int[] arr = new int[5];

            int[] arrs = new int[3] { 1, 2, 3 };

            int[] arrs1 = new int[] { 1, 2, 3 };

            int[] arr2 = { 1, 2, 3 };

            //int[] arr3 = arr2;
            //for (int i = 0; i < arr3.Length; i++)
            //{
            //    Console.WriteLine(arr3[i]);
            //}
            //arr3[2] = 4;

            int[,] multi = new int[2, 3] { { 2, 3, 4 }, { 1, 2, 3, } };
            Console.WriteLine(multi[0, 0]);
            Console.WriteLine(multi[1, 1]);
        }

        public static void FillArray()
        {
            int[] SARR = new int[10];

            for (int i = 0; i < SARR.Length; i++)
            {
                SARR[i] = i + 100;
            }

            for (int i = 0; i < SARR.Length; i++)
            {
                Console.WriteLine(SARR[i]);
            }
        }

        public static void FillArraywithForEach()
        {
            int[] ARR = new int[10];
            for(int i=0; i<ARR.Length; i++)
            {
                ARR[i] = i + 100;
            }
            foreach(var Arr in ARR)
            {
                Console.WriteLine(Arr);
            }
        }

        public static void MultiDimensionalArrays()
        {
            string[,] names;
            string[,,] namess;
            int[,] table = new int[5, 3] { { 1, 2,3}, {4,5,6 },{7,8,9 },{10,11,12 },{ 13,14,15} };

            for(int i=0; i<5; i++)
            {
                for(int j=0; j< 3; j++)
                {
                    Console.WriteLine(table[i, j]);
                }
            }
        }

        public static void JaggedArrays()
        {
            int[][] JaggedArr = new int[2][] { new int[] {1,2,3 }, new int[] {1,2,3 } };


            Console.WriteLine(JaggedArr[0][1]);
        }
    }
}
